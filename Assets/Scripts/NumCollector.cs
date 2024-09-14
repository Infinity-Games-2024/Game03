using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class NumCollector : MonoBehaviour
{
    [SerializeField] private AudioSource NumSoundEffect;
    [SerializeField] private Animator Animator;
    [SerializeField] private float animationDuration = 1f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            NumSoundEffect.Play();

            //play the explosion animation
            Animator.SetTrigger("explode");
            //Animator.Play("ExplorationAnimation());

            //Add to the player's score
            //PlayerManager.numberOfCoins++;
            //PlayerPrefs.SetInt("NumberOfCoins", PlayerManager.numberOfCoins);

            StartCoroutine(DestroyAfterAnimation());//

        }

    }

    private IEnumerator DestroyAfterAnimation()
    {
        //wait for the length of the explosion animation
        yield return new WaitForSeconds(animationDuration);
        PlayerManager.numberOfCoins++;
        PlayerPrefs.SetInt("NumberOfCoins", PlayerManager.numberOfCoins);
        Destroy(gameObject);//

    }
}
