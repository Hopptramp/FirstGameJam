using UnityEngine;
using System.Collections;

public class SideBullet : MonoBehaviour {

    [SerializeField]float speed;
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

    public void isLeft(bool isLeft)
    {
        if(isLeft == true)
        {
            setSpeed(4.0f);
            Debug.Log("boop");
        }
        else if (isLeft == false)
        {
            setSpeed(-4.0f);
            
        }
        else
        {
            Debug.Log("Error, sideshooter not set side, reverting to being right");
            setSpeed(-4.0f);
        }
    }

    public void OnCollisionEnter2D(Collision2D _collision)
    {
        if (_collision.gameObject.tag == "Enemy")
        {
            Physics2D.IgnoreCollision(_collision.collider, GetComponent<Collider2D>());
        }
    }

    public void setSpeed(float speedToSet)
    {
        speed = speedToSet;
    }

    public float getSpeed()
    {
        return speed;
    }

    public float getTimer()
    {
        return deathTimer;
    }

    public void setTimer(float timerToSet)
    {
        deathTimer = timerToSet;
    }

    public void BulletHit()
    {
        ParticleSystem[] particles = new ParticleSystem[2];
        particles = GetComponentsInChildren<ParticleSystem>();

        for (int i = 0; i < particles.Length; ++i)
        {
            particles[i].Stop();
        }

        Invoke("DestroySelf", 2);
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
