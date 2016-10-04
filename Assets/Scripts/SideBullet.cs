using UnityEngine;
using System.Collections;

public class SideBullet : bulletscript {

    float speed = -4.0f;
    float deathTimer = 0.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        deathTimer++;

        Vector3 newPosition = new Vector3(getSpeed(), 0, 0);

        transform.Translate(newPosition * Time.deltaTime);

        if (getTimer() > 1000.0f)
        {
            Destroy(gameObject);
        }
    }

  
}
