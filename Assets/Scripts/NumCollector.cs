using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumCollector : MonoBehaviour
{
    [SerializeField] private AudioSource NumSoundEffect;
    //[SerializeField] private Text numSubtitle;//added
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            NumSoundEffect.Play();
            //numSubtitle.text = "uno";
            Destroy(gameObject,2);//Destroy Num1 itself when player touches it
        }
    }
}


/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumCollector : MonoBehaviour
{

    [SerializeField] private AudioSource NumSoundEffect;
    [SerializeField] private Text numSubtitle;//added

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            NumSoundEffect.Play();

            // Identify number based on prefab name
            string prefabName = collision.gameObject.name;
            string collectedNumber = prefabName.Substring(6); // Assuming "Number" prefix

            // Update text based on number
            if (collectedNumber == "Num1")
            {
                numSubtitle.text = "uno";
            }
            else if (collectedNumber == "Num2")
            {
                numSubtitle.text = "due";
            }
            numSubtitle.text = "uno";

            Destroy(gameObject, 2);//Destroy Num1 itself when player touches it

        }
    }
}*/