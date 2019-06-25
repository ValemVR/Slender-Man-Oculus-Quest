using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessBzz : MonoBehaviour
{
    public Transform slender;
    public GameObject youDead;

    AudioSource bzzAudio;
    bool isLooking = false;
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
            isLooking = true;
            timeNotLooking = 0;
        }
        else
        {
            animator.SetBool("bzz", false);
            isLooking = false;
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
