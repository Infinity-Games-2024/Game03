using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform player;

    // Update is called once per frame
    private void LateUpdate()
    {
        transform.position = new Vector3(player.position.x+5.5f,player.position.y,transform.position.z);
    }
}
