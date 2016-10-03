using UnityEngine;
using System.Collections;
using System;

public class DerpyShooter : Enemy
{

    // Update is called once per frame
    void Update()
    {
        shotTimer++;

        if (flip)
        {
            if (actualDirection == direction.right) //move left
            {
                setSpeed(10000.0f);
                Vector3 newPosition = new Vector3(getSpeed(), 0, 0);

                _rb.AddForce(newPosition * Time.deltaTime);
                //transform.Translate(newPosition * Time.deltaTime);
            }
            else if (actualDirection == direction.left) //move right
            {
                setSpeed(-10000.0f);
                Vector3 newPosition = new Vector3(getSpeed(), 0, 0);

                _rb.AddForce(newPosition * Time.deltaTime);
                //transform.Translate(newPosition * Time.deltaTime);
            }
            else
            {
               // Debug.Log("Error. Derpyshooter has no valid direction");
            }
            flip = false;
        }

        if (getTimer() == timeToShoot) //shoot
        {
            // Debug.Log("Pew");
            setTimer(0);
            
            fire();
           
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
                //Debug.Log("Bounce off left");
                flip = true;
            }
            else if (actualDirection == direction.right)
            {
                actualDirection = direction.left;
                //Debug.Log("Bounce off right");
                flip = true;
            }
            else
            {
                Debug.Log("Error: Derpyshooter hit a wall and couldn't change direction");
            }
        }
    }
}
