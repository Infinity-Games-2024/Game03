using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private AudioSource deathSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.CompareTag("Trap"))
        if(collision.transform.tag=="Trap")//GDTitan's enamy 
        {
            //Debug.Log("Over");
            Die();
            AudioManager.instance.Play("GameOver");
            PlayerManager.isGameOver = true;
            //gameObject.SetActive(false);//GDTitan: Player Disappears
        }
        /*
        if (collision.transform.tag == "Finish")
        {
            //AudioManager.instance.Play("GameWin");
            //Finish.finishSound.Play();
            PlayerManager.isGameWin = true;
            //Finish.levelCompleted = true;
            Invoke("CompleteLevel", 3.2f);
        }*/
    }

    private void Die()
    {
        deathSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("dead");
    }

    /*
    private void Restartlevel()
    {

        //SceneManager.LoadScene(SceneManager.GetActiveScene().name); //GDTitan
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//CodeInFlow
    }*/
}
