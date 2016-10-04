using UnityEngine;
using System.Collections;

public class EnviromentDestroyer : MonoBehaviour {

	public AudioClip CollisionSound;

	void update()
	{
		
	}

    void OnTriggerEnter2D(Collider2D _collider)
    {
        if(_collider.gameObject.tag == "Bullet" || _collider.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
		if (_collider.gameObject.tag == "Player") 
		{
			GetComponent<AudioSource>().Play();
		}
    }
}
