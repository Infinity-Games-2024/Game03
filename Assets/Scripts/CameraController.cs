using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform player;

    public void GoHome()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
    // Update is called once per frame
    private void LateUpdate()
    {
        transform.position = new Vector3(player.position.x+2.7f,player.position.y+1.5f,transform.position.z);
    }
}
