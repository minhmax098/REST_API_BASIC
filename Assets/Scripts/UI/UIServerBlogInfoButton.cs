using UnityEngine;

/// <summary>
/// This is Blog Info Button script.
/// It's responsible for sending GetBlogInfo request to the server.
/// </summary>
public class UIServerBlogInfoButton : MonoBehaviour
{
    // Reference to label in scene.
    [SerializeField]
    private UIServerResponseViewer display;

    /// <summary>
    /// Method called on button click event.
    /// </summary>
    public void CallAPI()
    {
        display.ClearMessage();
        ServerCommunication.Instance.GetBlogInfo(APICallSucceed, APICallFailed);
    }

    /// <summary>
    /// Request was successful
    /// </summary>
    /// <param name="blogInfoData">Blog info data.</param>
    private void APICallSucceed(BlogInfoData blogInfoData)
    {
        display.ShowMessage(string.Format("Blog: {0}\nAuthor: {1}\nHis age: {2}", blogInfoData.blogAddress, blogInfoData.bloggerName, blogInfoData.bloggerAge));
    }

    /// <summary>
    /// There were some problems with request.
    /// </summary>
    /// <param name="errorMessage">Error message.</param>
    private void APICallFailed(string errorMessage)
    {
        display.ShowMessage(string.Format("Error\n{0}", errorMessage));
    }
}
