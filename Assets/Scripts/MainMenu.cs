using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        //SceneManager.LoadSceneAsync("SampleScene");
        //Invoke("Start", 30f);

        /*
        bool buttonPressed = false;
        float timer = 0;
        float duration = 3f; //quarter second

        if (buttonPressed)
        {
            timer += Time.deltaTime;
            if (timer >= duration)
            {
                timer = 0;
                buttonPressed = false;
                //Run button press
            }
        }
        */

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
    public void QuitGame()
        {
            Application.Quit();
        }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
