using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Finish : MonoBehaviour
{

    //[SerializeField] private Text subtitleText;//SubtitleA
    private AudioSource finishSound;//Private before
    // Start is called before the first frame update

    private bool levelCompleted=false; //before static
    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.CompareTag("TitanPlayer02")&& !levelCompleted) 
        bool win = ((collision.gameObject.name == "TitanPlayer01(Clone)")||(collision.gameObject.name == "TitanPlayer02(Clone)")||(collision.gameObject.name == "TitanPlayer03(Clone)")); //anyone of the 3 characters win through the gate, it will pass to the next level
        if(win && !levelCompleted)
        {
            UnlockNewLevel();//added Unlock Level Map
            //ResetPlayerPrefs();//Reset stored PlayerPrefs Level Data
            finishSound.Play();
            AudioManager.instance.Play("GameWin");
            PlayerManager.isGameWin = true;
            levelCompleted = true;
            Invoke("CompleteLevel", 3.2f); // add 2.8s during level transition
            //CompleteLevel();
        }

    }

    private void CompleteLevel()//Private Before
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
