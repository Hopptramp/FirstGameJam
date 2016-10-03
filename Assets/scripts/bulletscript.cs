using UnityEngine;
using System.Collections;

public class bulletscript : MonoBehaviour {

    float speed = -4.0f;
    float deathTimer = 0.0f;

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

    void OnCollisionEnter2D(Collision2D _collision)
    {
        if(_collision.gameObject.tag == "Enemy")
        {
            Physics2D.IgnoreCollision(_collision.collider, GetComponent<Collider2D>());
        }
    }

    void setSpeed(float speedToSet)
    {
        speed = speedToSet;
    }

    float getSpeed()
    {
        return speed;
    }

    float getTimer()
    {
        return deathTimer;
    }

    void setTimer(float timerToSet)
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
