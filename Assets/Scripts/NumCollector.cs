using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumCollector : MonoBehaviour
{
   
    [SerializeField] private AudioSource NumSoundEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            NumSoundEffect.Play();
            Destroy(gameObject,2);//Destry Num1 itself when player touches it
            
        }
    }
}