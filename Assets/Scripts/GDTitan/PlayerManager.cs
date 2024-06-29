using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;

public class PlayerManager : MonoBehaviour
{
    public static Vector2 lastCheckPointPos = new Vector2(-3, 0);

    public CinemachineVirtualCamera VCam;
    public GameObject[] playerPrefabs;
    int characterIndex;

    private void Awake()
    {
        //Below 4 lines were commented in 28th June Friday
        //characterIndex = PlayerPrefs.GetInt("SelectedCharacter",0);
        //GameObject player = Instantiate(playerPrefabs[characterIndex],lastCheckPointPos, Quaternion.identity);
     
        //VCam.m_Follow = player.transform;
        //isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
