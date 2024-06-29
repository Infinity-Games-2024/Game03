using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController2 : MonoBehaviour
{
    public void GoHome()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

}