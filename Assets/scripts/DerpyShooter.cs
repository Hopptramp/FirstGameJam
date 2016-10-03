using UnityEngine;
using System.Collections;
using System;

public class DerpyShooter : MonoBehaviour
{
    
    public GameObject bullet;

    private int shotTimer = 0;
    private float speed;
    private Rigidbody2D _rb;
    public bool flip;
    int timeToShoot;

    enum direction //enum which controls direction of derpyshooter
    {
        left = 0,
        right = 1
    }

    direction actualDirection = direction.left;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        flip = true;
        timeToShoot = 200;
    }

    // Update is called once per frame
    void Update()
    {
        shotTimer++;

        if (flip)
        {
            if (actualDirection == direction.right) //move left
            {
                setSpeed(1.0f);
                Vector3 newPosition = new Vector3(getSpeed(), 0, 0);

                _rb.AddForce(newPosition * Time.deltaTime * 25000.0f);
                //transform.Translate(newPosition * Time.deltaTime);
            }
            else if (actualDirection == direction.left) //move right
            {
                setSpeed(-1.0f);
                Vector3 newPosition = new Vector3(getSpeed(), 0, 0);

                _rb.AddForce(newPosition * Time.deltaTime * 25000.0f);
                //transform.Translate(newPosition * Time.deltaTime);
            }
            else
            {
                Debug.Log("Error. Derpyshooter has no valid direction");
            }
            flip = false;
        }

        if (getTimer() == timeToShoot) //shoot
        {
            // Debug.Log("Pew");
            setTimer(0);
            
            fire();
            if (timeToShoot != 5)
            {
                timeToShoot = timeToShoot - 5;
            }
        }

       /* if (transform.position.x <= boundLeft) //bounce off the left
        {
            actualDirection = direction.right;
            Debug.Log("Bounce off left");
            flip = true;
        }

        if (transform.position.x >= boundRight) //bounce off the right
        {
            actualDirection = direction.left;
            Debug.Log("Bounce off right");
            flip = true;
        }*/
    }

    void OnTriggerStay2D(Collider2D _collision)
    {
        
        if(_collision.gameObject.tag == "Wall")
        {
            
            if(actualDirection == direction.left)
            {
                actualDirection = direction.right;
                Debug.Log("Bounce off left");
                flip = true;
            }
            else if (actualDirection == direction.right)
            {
                actualDirection = direction.left;
                Debug.Log("Bounce off right");
                flip = true;
            }
            else
            {
                Debug.Log("Error: Derpyshooter hit a wall and couldn't change direction");
            }
        }
    }

    void fire()
    {
        Vector3 firePort = transform.position;
        firePort.y = firePort.y - 4;
        Instantiate(bullet, firePort, Quaternion.identity);
    }

    void setSpeed(float setToSpeed)
    {
        speed = setToSpeed;
    }

    float getSpeed()
    {
        return speed;
    }

    void setTimer(int timerToSet)
    {
        shotTimer = timerToSet;
    }

    int getTimer()
    {
        return shotTimer;
    }
}
