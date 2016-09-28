using UnityEngine;
using System.Collections;


public class DerpyShooter : MonoBehaviour {

    public GameObject bullet;
    public GameObject derpyShooter;

    float boundLeft = -10.0f;
    float boundRight = 10.0f;

    private float shotTimer = 0.0f;
    private float speed;

    enum direction //enum which controls direction of derpyshooter
    {
        left = 0,
        right = 1
    }

    direction actualDirection = direction.left;

	
	// Update is called once per frame
	void Update ()
    {
        shotTimer++;

        if(actualDirection == direction.right) //move left
        {
            setSpeed(1.0f);
            Vector3 newPosition = new Vector3(getSpeed(), 0, 0);

            transform.Translate(newPosition * Time.deltaTime);
        }
        else if (actualDirection == direction.left) //move right
        {
            setSpeed(-1.0f);
            Vector3 newPosition = new Vector3(getSpeed(), 0, 0);

            transform.Translate(newPosition * Time.deltaTime);
        }
        else
        {
            Debug.Log("Error. Derpyshooter has no valid direction");
        }

        if(getTimer() == 200.0f) //shoot
        {
           // Debug.Log("Pew");
            setTimer(0.0f);
            fire();
        }

        if(derpyShooter.transform.position.x <= boundLeft) //bounce off the left
        {
            actualDirection = direction.right;
            Debug.Log("Bounce off left");
        }
        if(derpyShooter.transform.position.x >= boundRight) //bounce off the right
        {
            actualDirection = direction.left;
            Debug.Log("Bounce off right");
        }
	}

    void fire()
    {
        Instantiate(bullet, derpyShooter.transform.position, derpyShooter.transform.rotation);
    }

    void setSpeed(float setToSpeed)
    {
        speed = setToSpeed;
    }

    float getSpeed()
    {
        return speed;
    }

    void setTimer(float timerToSet)
    {
        shotTimer = timerToSet;
    }

    float getTimer()
    {
        return shotTimer;
    }
}
