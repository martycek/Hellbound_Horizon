using UnityEngine;
using UnityEngine.UI;

public class OpenHyperlink : MonoBehaviour
{
    public string hyperlinkURL = "https://assetstore.unity.com/packages/templates/systems/2d-action-platformer-game-system-200714"; // Change this to your desired URL

    void Start()
    {
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OpenHyperlinkOnClick);
        }
        else
        {
            Debug.LogError("This script should be attached to a UI button.");
        }
    }

    void OpenHyperlinkOnClick()
    {
        Application.OpenURL(hyperlinkURL);
    }
}
