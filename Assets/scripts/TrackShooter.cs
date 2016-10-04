using UnityEngine;
using System.Collections;

public class TrackShooter : Enemy
{
    [SerializeField]private float drag = 400.0f;
    [SerializeField]private GameObject trackedPlayer;

    void Start()
    {
        trackedPlayer = player1;
    }

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

        if (trackedPlayer.transform.position.x >= gameObject.transform.position.x) //bounce off the left
        {
            actualDirection = direction.right;
            //Debug.Log("Bounce off left");
            flip = true;
        }
        else if (trackedPlayer.transform.position.x <= gameObject.transform.position.x) //bounce off the right
        {
            actualDirection = direction.left;
            //Debug.Log("Bounce off right");
            flip = true;
        }

        selectTarget();

        if (((trackedPlayer.transform.position.x <= gameObject.transform.position.x + 1.0f) && ((trackedPlayer.transform.position.x >= gameObject.transform.position.x - 1.0f))) && (getTimer() >= timeToShoot)) //shoot
        {
            setTimer(0);

            fire();
            //Debug.Log("Pew");
            
            flip = false;
        }
    }

    void selectTarget() //changes the target of the track shooter based on how high the players are
    {
        //Debug.Log("Hit");
        if (player1.transform.position.y > player2.transform.position.y)
        {
            trackedPlayer = player1;
            //Debug.Log("Switch");
        }
        else if(player1.transform.position.y < player2.transform.position.y)
        {
            trackedPlayer = player2;
            //Debug.Log("Switch");
        }
        else
        {
            //don't change
        }
    }


}
