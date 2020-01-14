using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadThisSceneAfterXSeconds : MonoBehaviour
{
    public float time = 4;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Reload", time);
    }

    private void Reload()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}
