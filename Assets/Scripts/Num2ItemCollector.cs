using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Num2ItemCollector : MonoBehaviour
{
    public int collected { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Num2"))
        {
            Destroy(collision.gameObject);
            int Num1Collected = FindObjectOfType<Num1ItemCollector>().GetCollected();
            collected = Num1Collected + 1;// trying to get sum of collected numbers, but it added 1,2,3 then jump to 6
            Debug.Log("Collected: "+collected);
        }
    }

    public int GetCollected()
    {
        return collected;
    }

}
