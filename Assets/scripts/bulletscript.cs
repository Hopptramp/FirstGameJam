using UnityEngine;
using System.Collections;

public class bulletscript : MonoBehaviour {

    float speed = -4.0f;
    float deathTimer = 0.0f;

	public AudioClip CollisionSound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        deathTimer++;

        Vector3 newPosition = new Vector3(0, getSpeed(), 0);

        transform.Translate(newPosition * Time.deltaTime);

        if(getTimer() > 1000.0f)
        {
            Destroy(gameObject);
        }
	}

    public void OnCollisionEnter2D(Collision2D _collision)
    {
        if(_collision.gameObject.tag == "Enemy")
        {
            Physics2D.IgnoreCollision(_collision.collider, GetComponent<Collider2D>());
        }
    }

	void OnTriggerEnter2D(Collider2D _collider)
	{
		if (_collider.gameObject.tag == "Player") 
		{
			GetComponent<AudioSource>().Play();
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
