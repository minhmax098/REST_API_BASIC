using UnityEngine;
using TMPro;

/// <summary>
/// This class is responsible for label control.
/// </summary>
public class UIServerResponseViewer : MonoBehaviour
{
    // Reference to label.
    [SerializeField]
    private TextMeshProUGUI label;

    /// <summary>
    /// Method used to display message on screen.
    /// </summary>
    /// <param name="message">Message.</param>
    public void ShowMessage(string message)
    {
        label.text = message;
    }

    /// <summary>
    /// Method used to clear label content.
    /// </summary>
    public void ClearMessage()
    {
        label.text = string.Empty;
    }
}
