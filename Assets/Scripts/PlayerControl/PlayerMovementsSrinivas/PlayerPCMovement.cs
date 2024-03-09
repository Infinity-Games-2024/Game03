using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPCMovement : MonoBehaviour
{
    string m_DeviceType;
    private Rigidbody2D rb;//short for rigidbody
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    //public AudioSource audioPlayer;//Adding Sound Effect Part1, Not Working Later

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private enum MovementState { idle, running, jumping, falling, death }

    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
       

        /*// Implemented Touch Bard starts here
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Get normalized position of touch on screen (0 to 1)
            float touchPos = touch.position.x / Screen.width;

            // Set movement direction based on touch position
            if (touchPos > 0.5f)
            {
                dirX = 1f; // Move right
            }
            else
            {
                dirX = -1f; // Move left
            }
        }
        else
        {
            dirX = 0f; // No touch, stop movement
        }
        *///Implemented Touch Input from Bard ends here
        
        dirX = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimationUpdate();   
    }

    private void UpdateAnimationUpdate()
    {
        //print("Hello");
        //Debug.Log("Hello");
        MovementState state;
        if (dirX > 0f)
        {
            //anim.SetBool("running", true);
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            //anim.SetBool("running", true);
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            //anim.SetBool("running", false);
            state = MovementState.idle;
        }

        if (rb.velocity.y > .01f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.01f)
        {
            state = MovementState.falling;
        }
        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

}
