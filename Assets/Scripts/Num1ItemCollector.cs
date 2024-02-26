using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Num1ItemCollector : MonoBehaviour
{
    public int collected=0;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Num1"))
        {
            Destroy(collision.gameObject);
            int Num2Collected = FindObjectOfType<Num2ItemCollector>().GetCollected();
            collected =collected+Num2Collected+1;
            Debug.Log("Collected: " + collected);
        }
    }

    public int GetCollected()
    {
        return collected;
    }
}
