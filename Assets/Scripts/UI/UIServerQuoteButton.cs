using UnityEngine;

/// <summary>
/// This is Quote Button script.
/// It's responsible for sending GetQuote request to the server.
/// </summary>
public class UIServerQuoteButton : MonoBehaviour
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
        ServerCommunication.Instance.GetQuote(APICallSucceed, APICallFailed);
    }

    /// <summary>
    /// Request was successful
    /// </summary>
    /// <param name="quoteData">Quote data.</param>
    private void APICallSucceed(QuoteData quoteData)
    {
        display.ShowMessage(string.Format("{0}\n- {1}", quoteData.quote, quoteData.author));
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
