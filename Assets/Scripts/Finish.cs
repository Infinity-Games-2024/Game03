using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{

    //[SerializeField] private Text subtitleText;//SubtitleA
    private AudioSource finishSound;
    // Start is called before the first frame update

    private bool levelCompleted=false; 
    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.CompareTag("Player")) 
        if(collision.gameObject.name=="Player" && !levelCompleted)
        {
            UnlockNewLevel();//added Unlock Level Map
            //subtitleText.text = "uno";//SubtitleB
            finishSound.Play();
            levelCompleted = true;
            Invoke("CompleteLevel", 3.8f); // add 2s during level transition
            //CompleteLevel();
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void UnlockNewLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
    }
}
