using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextSceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        SceneManager.LoadScene("Level 1",LoadSceneMode.Single);        
    }
}