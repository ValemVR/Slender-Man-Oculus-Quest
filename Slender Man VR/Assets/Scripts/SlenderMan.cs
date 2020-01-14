using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlenderMan : MonoBehaviour
{
    Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    { 
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //If we dont look at him for x sec or we are too far, he changes its position after x sec
        if(PostProcessBzz.timeNotLooking > 8)
        {
            PostProcessBzz.timeNotLooking = 0;
            Spawn();
        }

        //Keep on facing player
        transform.LookAt(new Vector3(mainCamera.transform.position.x, transform.position.y, mainCamera.transform.position.z));
    }

    void Spawn()
    {
        RaycastHit hit;
        float randomDistance = Random.Range(10, 20);
        float randomAngle = Random.Range(0, 360);

        Vector3 raySpawnPosition = mainCamera.transform.position
                    + new Vector3(randomDistance * Mathf.Cos(randomAngle), 50, randomDistance * Mathf.Sin(randomAngle));

        // note that the ray starts at 100 units
        Ray ray = new Ray(raySpawnPosition, Vector3.down);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.collider != null)
            {
                // this is where the gameobject is actually put on the ground
                transform.position = hit.point;
            }
        }
    }
}
