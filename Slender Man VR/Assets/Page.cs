using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page : MonoBehaviour
{
    static int numberofpages = 0;
    public GameObject win;
    public AudioSource pagesound;

    private void Start()
    {
        numberofpages = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        pagesound.Play();
        numberofpages++;

        if(numberofpages == 5)
        {
            win.SetActive(true);
        }

        Destroy(gameObject);
    }
}
