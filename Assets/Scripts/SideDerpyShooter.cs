using UnityEngine;
using System.Collections;

public class SideDerpyShooter : Enemy
{
    public SideBullet sideBullet;
    //[SerializeField]
    //public bool isLeft;
    void Start()
    {
        //setSide(isLeft);
    }

    void Update()
    {
        shotTimer++;

        if (flip)
        {
            if (actualDirection == direction.right) //move left
            {
                setSpeed(40000.0f);
                Vector3 newPosition = new Vector3(0, getSpeed(), 0);

                _rb.AddForce(newPosition * Time.deltaTime);
                //transform.Translate(newPosition * Time.deltaTime);
            }
            else if (actualDirection == direction.left) //move right
            {
                setSpeed(-40000.0f);
                Vector3 newPosition = new Vector3(0, getSpeed(), 0);

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
        //Debug.Log("boop");

        if (_collision.gameObject.tag == "Cieling" || _collision.gameObject.tag == "DeathCollider")
        {
            

            if (actualDirection == direction.left)
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

    void fire()
    {
        if (timeToShoot != 40) //slowly increases shot rate
        {
            timeToShoot = timeToShoot - 10;
        }

        Vector3 firePort = transform.position;
        firePort.y = firePort.x - 4;
        Instantiate(sideBullet, firePort, Quaternion.identity);

    }

    public void setSide(bool side)//true is on left shooting right, false is on right shooting left
    {
        //side = false;
        //isLeft = side;
        sideBullet.isLeft(side);
    }
}

