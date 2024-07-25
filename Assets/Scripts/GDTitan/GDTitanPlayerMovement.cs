using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Tilemaps;
using UnityEngine;

public class GDTitanPlayerMovement : MonoBehaviour
{
    PlayerControls controls;
    float direction = 0;

    public float speed = 200;
    bool isFacingRight = true;

    public float jumpForce=10;
    bool isGrounded;
    int numberOfJumps = 0;
    public Transform groundCheck;
    public LayerMask groundLayer; //once spelt wrong 

    public Rigidbody2D playerRB;
    public Animator animator;
    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    private void Awake()
    {
        controls = new PlayerControls();
        controls.Enable();

        controls.Land.Move.performed += ctx =>
        {
            direction = ctx.ReadValue<float>();
        };

        controls.Land.Jump.performed += ctx => Jump();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        //Debug.Log(isGrounded);
        animator.SetBool("isGrounded", isGrounded);

        playerRB.velocity = new Vector2 (direction* speed * Time.fixedDeltaTime, playerRB.velocity.y);
        animator.SetFloat("speed",Mathf.Abs(direction));

        if(isFacingRight && direction <0 || !isFacingRight && direction >0) 
            Flip();

    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector2(transform.localScale.x*-1,transform.localScale.y);        
    }

    void Jump()
    {
        //
        if (isGrounded)
        {
            numberOfJumps = 0;
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
            jumpSoundEffect.Play();
            //AudioManager.instance.Play("FirstJump");
            numberOfJumps++;
        }
        else
        {
            if (numberOfJumps == 1)
            {
                playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
                jumpSoundEffect.Play();
                //AudioManager.instance.Play("SecondJump");
                numberOfJumps++;
            }
        }

    }
}
