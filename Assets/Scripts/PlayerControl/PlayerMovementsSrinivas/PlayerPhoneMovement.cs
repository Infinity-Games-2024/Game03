using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPhoneMovement : MonoBehaviour
{
    public Joystick joystick;// Joystick for movement
    public Button buttonJump;// Button for jumping
    public bool isButtonPressed;// Flag to check if jump button is pressed
    private Rigidbody2D rb;//short for rigidbody
    private BoxCollider2D coll;// Rigidbody component for physics
    private SpriteRenderer sprite;// Collider component for ground detection
    private Animator anim;// Sprite renderer for flipping character
    //public AudioSource audioPlayer;//Adding Sound Effect Part1, Not Working Later

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float jumpForce = 17f;
    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private float joystickThreshold = 0.18f;

    private float dirX = 0f;
    string m_DeviceType;
    //private float dirY = 0f;
    private enum MovementState { idle, running, jumping, falling, death }

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        buttonJump.onClick.AddListener(ButtonPressed);

#if UNITY_WEBGL && !UNITY_EDITOR
    m_DeviceType = "PC";
#else
        m_DeviceType = "Mobile";
        // Use joystick and button controls on mobile or editor
#endif
    }

    private void ButtonPressed()//Gemini
    {
        isButtonPressed = true;
        //Gemini: isButtonPressed after a short time(optional)
        StartCoroutine(ResetJumpPressAfterTime(0.1f));
    }
    private IEnumerator ResetJumpPressAfterTime(float time)//Gemini
    {
        yield return new WaitForSeconds(time);
        isButtonPressed = false;
    }
    private void HandleMovement()
    {
        //dirX = joystick.Horizontal*moveSpeed;
        /*if (joystick.Horizontal >= 0.18f)
        {
            dirX = joystick.Horizontal * moveSpeed;
        }
        else if (joystick.Horizontal <= -0.18f)
        {
            dirX = joystick.Horizontal * moveSpeed;
        }*/
        //dirY = joystick.Vertical * moveSpeed;
        if (m_DeviceType == "PC")
        {
            dirX = Input.GetAxis("Horizontal") * moveSpeed;
        }
        else
        {
            if (Mathf.Abs(joystick.Horizontal) >= joystickThreshold)
            {
                dirX = joystick.Horizontal * moveSpeed;
            }
            else
            {
                dirX = 0f;
            }
        }
        rb.velocity = new Vector2(dirX * moveSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    private void HandleJump()
    {
        if ((Input.GetButtonDown("Jump") || isButtonPressed == true) && IsGrounded())//IsGrounded DoubleJump
        //if ((Input.GetButtonDown("Jump") || isButtonPressed == true))
        {

            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x*Time.fixedDeltaTime, jumpForce);
            //isButtonPressed = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandleMovement();
        HandleJump();
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