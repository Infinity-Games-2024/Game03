using UnityEngine;
using UnityEngine.UI;

public class NameInputManager : MonoBehaviour
{
    public InputField nameInputField;
    public Button submitButton;
    public static string playerName;

    void Start()
    {
        submitButton.onClick.AddListener(OnSubmitName);
    }

    void OnSubmitName()
    {
        playerName = nameInputField.text;
        // Hide the input name screen and start the game
        gameObject.SetActive(false);
    }
}
