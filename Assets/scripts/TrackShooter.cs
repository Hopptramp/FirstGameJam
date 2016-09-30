using UnityEngine;
using System.Collections;

public class TrackShooter : MonoBehaviour
{

    public GameObject bullet;
    //public GameObject trackShooter;
    public GameObject player;

    private float shotTimer = 0.0f;
    private float speed;
    private Rigidbody2D _rb;
    public bool flip;

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
        player = GameObject.FindGameObjectWithTag("Player");
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

                _rb.AddForce(newPosition * Time.deltaTime * 500.0f);
                //transform.Translate(newPosition * Time.deltaTime);
            }
            else if (actualDirection == direction.left) //move right
            {
                setSpeed(-1.0f);
                Vector3 newPosition = new Vector3(getSpeed(), 0, 0);

                _rb.AddForce(newPosition * Time.deltaTime * 500.0f);
                //transform.Translate(newPosition * Time.deltaTime);
            }
            else
            {
                Debug.Log("Error. Derpyshooter has no valid direction");
            }
            flip = false;
        }

        if (player.transform.position.x >= gameObject.transform.position.x) //bounce off the left
        {
            actualDirection = direction.right;
            Debug.Log("Bounce off left");
            flip = true;
        }
        else if (player.transform.position.x <= gameObject.transform.position.x) //bounce off the right
        {
            actualDirection = direction.left;
            Debug.Log("Bounce off right");
            flip = true;
        }

        if (((player.transform.position.x <= gameObject.transform.position.x + 1.0f) && ((player.transform.position.x >= gameObject.transform.position.x - 1.0f))) && (shotTimer >= 200.0f)) //shoot
        {
            Debug.Log("Pew");
            setTimer(0.0f);
            fire();
            flip = false;
        }

  
      
    }

    void fire()
    {
        Instantiate(bullet, gameObject.transform.position, gameObject.transform.rotation);
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
