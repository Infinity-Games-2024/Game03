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
            //ResetPlayerPrefs();//Reset stored PlayerPrefs Level Data
            finishSound.Play();
            levelCompleted = true;
            Invoke("CompleteLevel", 3.5f); // add 3.5s during level transition
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

    
    void ResetPlayerPrefs()//reset level data, added in 05062024
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("PlayerPrefs data reset!"); // Optional: Log a message to the console
    }
}
