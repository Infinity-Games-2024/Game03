using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhoneMovement : MonoBehaviour
{
    public Joystick joystick;//Brackevs Srinivas, adding Joystick
    string m_DeviceType;
    private Rigidbody2D rb;//short for rigidbody
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    //public AudioSource audioPlayer;//Adding Sound Effect Part1, Not Working Later

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    private float dirY = 0f;
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

        //dirX = joystick.Horizontal*moveSpeed;
        if(joystick.Horizontal >= .4f)
        {
            dirX = joystick.Horizontal * moveSpeed;
        }
        else if (joystick.Horizontal <= -.4f)
        {
            dirX = joystick.Horizontal * moveSpeed;
        }else
        {
            dirX = 0f;
        }

        dirY = joystick.Vertical*moveSpeed;

        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if ((Input.GetButtonDown("Jump") || dirY>0.6f)&& IsGrounded())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        AnimationUpdate();
    }

    private void AnimationUpdate()
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
