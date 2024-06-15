using UnityEngine;
using UnityEngine.UI;

public class SetPlaceholderText : MonoBehaviour
{
    public InputField nameInputField;

    void Start()
    {
        Text placeholderText = nameInputField.placeholder.GetComponent<Text>();
        placeholderText.text = "Enter your name";
    }
}