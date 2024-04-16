using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{

    PlayerControls controls;
    float direction = 0;

    public float speed = 400;
    bool isFacingRight = true;

    public Rigidbody2D playerRB;
    public Animator animator;

    private void Awake()
    {
        controls = new PlayerControls();
        controls.Enable();

        controls.Land.Move.performed += ctx =>
        {
            direction = ctx.ReadValue<float>();
        };
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerRB.velocity = new Vector2(direction * speed * Time.deltaTime, playerRB.velocity.y);
        animator.SetFloat("speed",Mathf.Abs(direction));

        if(isFacingRight && direction <0 || !isFacingRight && direction >0)
        {
            Flip();
        }
        void Flip()
        {
            isFacingRight = !isFacingRight;
            transform.localScale = new Vector2(transform.localScale.x *-1,transform.localScale.y);
        }
    }
}
