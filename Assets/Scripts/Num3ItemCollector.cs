using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Num3ItemCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Num3"))
        {
            Destroy(collision.gameObject);
        }
    }

}
