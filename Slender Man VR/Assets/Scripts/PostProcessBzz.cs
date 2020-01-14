using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostProcessBzz : MonoBehaviour
{
    public Transform slender;
    public GameObject youDead;

    AudioSource bzzAudio;
    Animator animator;
    
    static public float timeNotLooking = 0;

    private void Start()
    {
        bzzAudio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(slender.position, transform.position);
        float angle = Vector3.Angle(transform.forward, slender.position - transform.position);

        if (angle < 50 && distance < 15)
        {
            animator.SetBool("bzz", true);
            timeNotLooking = 0;
        }
        else
        {
            animator.SetBool("bzz", false);
            timeNotLooking += Time.deltaTime;
        }
    }

    public void YouDead()
    {
        youDead.SetActive(true);
        StopBzz();
    }

    public void PlayBzz()
    {
        bzzAudio.Play();
    }

    public void StopBzz()
    {
        bzzAudio.Stop();
    }
}
