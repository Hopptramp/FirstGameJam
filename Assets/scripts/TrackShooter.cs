using UnityEngine;
using System.Collections;

public class TrackShooter : Enemy
{
    [SerializeField]private float drag = 10.0f;

    // Update is called once per frame
    void Update()
    {
        shotTimer++;
        if (flip)
        {
            if (actualDirection == direction.right) //move left
            {
                setSpeed(1000.0f);
                Vector3 newPosition = new Vector3(getSpeed(), 0, 0);

                Vector3 worldDir = newPosition.normalized;

                Vector3 localDir = transform.InverseTransformDirection(worldDir);

                newPosition += 400.0f * Time.deltaTime * worldDir;

                _rb.AddForce(newPosition * Time.deltaTime);
                _rb.drag = (drag * Time.deltaTime);
                //transform.Translate(newPosition * Time.deltaTime);
            }
            else if (actualDirection == direction.left) //move right
            {
                setSpeed(-1000.0f);
                Vector3 newPosition = new Vector3(getSpeed(), 0, 0);

                Vector3 worldDir = newPosition.normalized;

                Vector3 localDir = transform.InverseTransformDirection(worldDir);

                newPosition += 400.0f * Time.deltaTime * worldDir;

                _rb.AddForce(newPosition * Time.deltaTime);
                _rb.drag = (drag * Time.deltaTime);
                //transform.Translate(newPosition * Time.deltaTime);
            }
            else
            {
                Debug.Log("Error. Trackshooter has no valid direction");
            }
            flip = false;
        }

        if (player.transform.position.x >= gameObject.transform.position.x) //bounce off the left
        {
            actualDirection = direction.right;
            //Debug.Log("Bounce off left");
            flip = true;
        }
        else if (player.transform.position.x <= gameObject.transform.position.x) //bounce off the right
        {
            actualDirection = direction.left;
            //Debug.Log("Bounce off right");
            flip = true;
        }

        if (((player.transform.position.x <= gameObject.transform.position.x + 1.0f) && ((player.transform.position.x >= gameObject.transform.position.x - 1.0f))) && (getTimer() >= timeToShoot)) //shoot
        {
            setTimer(0);

            fire();
            //Debug.Log("Pew");
            
            flip = false;
        }
    }


}
