using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitckyPlaftform : MonoBehaviour
{
    // Start is called before the first frame updates

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.gameObject.name == "Player" || collision.gameObject.name == "PlayerLevel2" || collision.gameObject.name == "PlayerLevel3")
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name=="Player"||collision.gameObject.name == "PlayerLevel2"||collision.gameObject.name=="PlayerLevel3")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
