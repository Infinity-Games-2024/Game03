using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int cherries = 0;

    [SerializeField] private Text cherriesText;

    [SerializeField] private Text levelText;//added

    [SerializeField] private Text subtitleText;//added

    [SerializeField] private AudioSource collectionSoundEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool numbers = collision.gameObject.CompareTag("Num1") || collision.gameObject.CompareTag("Num2") || collision.gameObject.CompareTag("Num3")|| collision.gameObject.CompareTag("Num4")||collision.gameObject.CompareTag("Num5")||collision.gameObject.CompareTag("Num6")||collision.gameObject.CompareTag("Num7")||collision.gameObject.CompareTag("Num8")||collision.gameObject.CompareTag("Num9")||collision.gameObject.CompareTag("Num10");
        levelText.text = "" + (SceneManager.GetActiveScene().buildIndex - 1) + "/8";
        if (numbers) 
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            cherries++;
            cherriesText.text = "Punto: " + cherries+"/20"; //10 changes, previously Cheeries: 

            if (collision.gameObject.CompareTag("Num1"))
            {
                subtitleText.text = "uno";
            }
            else if (collision.gameObject.CompareTag("Num2"))
            {
                subtitleText.text = "due";
            }
            else if (collision.gameObject.CompareTag("Num3"))
            {
                subtitleText.text = "tre";
            }
            else if (collision.gameObject.CompareTag("Num4"))
            {
                subtitleText.text = "quattro";
            }
            else if (collision.gameObject.CompareTag("Num5"))
            {
                subtitleText.text = "cinque";
            }
            else if (collision.gameObject.CompareTag("Num6"))
            {
                subtitleText.text = "sei";
            }
            else if (collision.gameObject.CompareTag("Num7"))
            {
                subtitleText.text = "sette";
            }
            else if (collision.gameObject.CompareTag("Num8"))
            {
                subtitleText.text = "otto";
            }
            else if (collision.gameObject.CompareTag("Num9"))
            {
                subtitleText.text = "nove";
            }
            else if (collision.gameObject.CompareTag("Num10"))
            {
                subtitleText.text = "dieci";
            }
        }

        
    }
    /*public void Update()
    {
        levelText.text = "" + (SceneManager.GetActiveScene().buildIndex-1)+"/8";
    } 
    */
}