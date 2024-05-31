using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int cherries = 0;
    private List<string> collectibleTags = new List<string>() { "Num1", "Num2", "Num3", "Num4", "Num5", "Num6", "Num7", "Num8", "Num9", "Num10" };
    private IEnumerator subtitleCoroutine; // Reference to the coroutine

    [SerializeField] private Text cherriesText;
    [SerializeField] private Text levelText; //added
    [SerializeField] private Text subtitleText; //added
    [SerializeField] private AudioSource collectionSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        levelText.text = "" + (SceneManager.GetActiveScene().buildIndex - 1) + "/8";

        if (collectibleTags.Contains(collision.gameObject.tag))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            cherries++;
            cherriesText.text = "điem:" + cherries; // Updated text format

            // Stop any running coroutine before starting a new one
            if (subtitleCoroutine != null)
            {
                StopCoroutine(subtitleCoroutine);
            }
            subtitleCoroutine = DisplaySubtitle(collision.gameObject.tag);
            StartCoroutine(subtitleCoroutine);
        }
    }

    IEnumerator DisplaySubtitle(string collectedNumber)
    {
        // Update subtitle text
        switch (collectedNumber)
        {
            case "Num1":
                subtitleText.text = "mot";
                break;
            // ... other cases for subtitle translations
            case "Num2":
                subtitleText.text = "hai";
                break;
            case "Num3":
                subtitleText.text = "ba";
                break;
            case "Num4":
                subtitleText.text = "bon";
                break;
            case "Num5":
                subtitleText.text = "năm";
                break;
            case "Num6":
                subtitleText.text = "sáu";
                break;
            case "Num7":
                subtitleText.text = "bay";
                break;
            case "Num8":
                subtitleText.text = "tám";
                break;
            case "Num9":
                subtitleText.text = "chín";
                break;
            case "Num10":
                subtitleText.text = "muoi";
                break;
            default:
                subtitleText.text = "";
                break;
        }

        // Wait for 1 second
        yield return new WaitForSeconds(1f);

        // Clear subtitle text
        subtitleText.text = "";
    }
}