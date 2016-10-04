using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public GameObject bullet;
    //public GameObject trackShooter;
    [SerializeField]
    public GameObject player1;
    [SerializeField]
    public GameObject player2;

    [SerializeField]
    public int timeToShoot;
    [SerializeField]
    public int shotTimer = 0;
    [SerializeField]
    public float speed;
    public Rigidbody2D _rb;
    [SerializeField]
    public bool flip;

    public enum direction //enum which controls direction of derpyshooter
    {
        left = 0,
        right = 1
    }

    public direction actualDirection = direction.left;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        flip = true;
        //player = GameObject.Find()
        timeToShoot = 200;
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void fire()
    {
        if (timeToShoot != 40) //slowly increases shot rate
        {
            timeToShoot = timeToShoot - 10;
        }

        Vector3 firePort = transform.position;
        firePort.y = firePort.y - 4;
        Instantiate(bullet, firePort, Quaternion.identity);

    }

    public void setSpeed(float setToSpeed)
    {
        speed = setToSpeed;
    }

    public float getSpeed()
    {
        return speed;
    }

    public void setTimer(int timerToSet)
    {
        shotTimer = timerToSet;
    }

    public int getTimer()
    {
        return shotTimer;
    }
}
