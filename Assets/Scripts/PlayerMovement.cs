using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
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
    [SerializeField] private float jumpForce = 8f;

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
        //Output the device type to the console window
        //Debug.Log("Device type : " + m_DeviceType);

        //Check if the device running this is a console
        /*
        if (UnityEngine.Device.SystemInfo.deviceType == DeviceType.Console)
        {
            //Change the text of the label
            m_DeviceType = "Console";
        }
        */
        //Check if the device running this is a desktop
        if (UnityEngine.Device.SystemInfo.deviceType == DeviceType.Desktop)
        {
            print("Hey");
            m_DeviceType = "Desktop";
            dirX = Input.GetAxisRaw("Horizontal");

            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                jumpSoundEffect.Play();
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }

            UpdateAnimationUpdate();
        }

        //Check if the device running this is a handheld
        if (UnityEngine.Device.SystemInfo.deviceType == DeviceType.Handheld)
        {
            m_DeviceType = "Handheld";
            //Debug.Log("Hello") ;

            UpdateAndriod();
        }

        /*
        //Check if the device running this is unknown
        if (UnityEngine.Device.SystemInfo.deviceType == DeviceType.Unknown)
        {
            m_DeviceType = "Unknown";
        }
        //print(m_DeviceType);
        */

       
    }

    //try to update on Andriod
    private void UpdateAndriod()
    {
        if (Input.touchCount > 0)
        {
            Touch touch=Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0f;
            transform.position = touchPosition;
           
        }
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

    /*
    //Adding Sound Effect Part2
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Num1")
        {
            audioPlayer.Play();
        }
    }
    //Part2 ends here
    */

}
