using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour 
{
	[SerializeField] float ascentSpeed = 0.25f;
	[SerializeField] float leanSpeed = 10.0f;
	[SerializeField] float dropSpeed = -2.0f;
	[SerializeField] float fallSpeed = -10.0f;
	[SerializeField] float boostedAscendSpeed = 7.0f;
	[SerializeField] float fallTime = 0.5f;

	[SerializeField] GameObject mainCam;
	[SerializeField] GameObject collisionParticle;
	[SerializeField] GameObject dropParticle;

	List<GameObject> currentCollisionParticles;
	List<GameObject> currentDropParticles;


	//bool doAscend = true;
	bool doBoost = false;

	public bool playerOne = true; // Set as false from scene manager for player 2 when instantiating
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();

		currentCollisionParticles = new List<GameObject> ();
		currentDropParticles = new List<GameObject> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey(playerOne ? KeyCode.W : KeyCode.I) && !doBoost)
		{
			ConstantAscent ();
		}
		if(Input.GetKey(playerOne ? KeyCode.A : KeyCode.J))
		{
			LeanDirection (-1);
		}
		else if(Input.GetKey(playerOne ? KeyCode.D : KeyCode.L))
		{
			LeanDirection (1);
		}
		if (Input.GetKeyDown (playerOne ? KeyCode.S : KeyCode.K)) 
		{
			Drop ();
			//doAscend = false;
		}
		if (Input.GetKeyDown (playerOne ? KeyCode.X : KeyCode.M))
			FallPlayer ();

		// if still in boost collider, keep applying boosted movement
		if (doBoost)
			BoostedAscent (doBoost);


		if (currentCollisionParticles.Count > 0) {
			for (int i = 0; i < currentCollisionParticles.Count; ++i) {
				if (!currentCollisionParticles [i].GetComponent<ParticleSystem> ().IsAlive()) {
					Destroy (currentCollisionParticles [i]);
					currentCollisionParticles.RemoveAt (i--);
				}
				}
		}
		if (currentDropParticles.Count > 0) {
			for (int i = 0; i < currentDropParticles.Count; ++i) {
				if (!currentDropParticles [i].GetComponent<ParticleSystem> ().IsAlive()) {
					Destroy (currentDropParticles [i]);
					currentDropParticles.RemoveAt (i--);
				}
			}
		}
	}

	void AllowAscent()
	{
		//doAscend = true;
		rb.gravityScale = 0.25f; // set back to default gravity scale
	}

	void ConstantAscent()
	{
		//rb.AddForce (new Vector2 (0, ascentSpeed));
		if (rb.velocity.y > ascentSpeed)
			rb.velocity = Vector2.Lerp (rb.velocity, new Vector2 (rb.velocity.x, ascentSpeed), 0.01f);
		else
			rb.velocity = new Vector2 (rb.velocity.x, ascentSpeed);
	}

	void LeanDirection(float input)
	{
		rb.AddForce ( new Vector2(input * leanSpeed, 0));
	}

	void Drop()
	{
		GameObject particle = Instantiate (dropParticle) as GameObject;
		particle.transform.position = transform.position;
		currentDropParticles.Add (particle);

		rb.AddForce(new Vector2(0, dropSpeed));
		rb.gravityScale = 2;
		Invoke ("AllowAscent", fallTime);
	}

	public void BoostedAscent(bool active)
	{
		if (active) {
			// apply force to the player
			rb.AddForce (new Vector2 (rb.velocity.x, boostedAscendSpeed));
			doBoost = true;
		} else {
			doBoost = false;
		}
	}

	public void FallPlayer()
	{
		//doAscend = false;
		rb.AddForce(new Vector2(0, fallSpeed));
		rb.gravityScale = 1;
		Invoke ("AllowAscent", 2 * fallTime);	
	}

    void OnTriggerEnter2D(Collider2D _collider)
    {
        if (_collider.gameObject.tag == "RayOfLight")
        {
            BoostedAscent(true);
        }
    }

	void OnCollisionEnter2D(Collision2D col)
	{
		mainCam.GetComponent<ScreenShake> ().ShakeScreen (0.1f);
		GameObject particle = Instantiate (collisionParticle) as GameObject;
		particle.transform.position = col.contacts [0].point;
		currentCollisionParticles.Add (particle);
	}

    void OnTriggerExit2D(Collider2D _collider)
    {
        if (_collider.gameObject.tag == "RayOfLight")
        {
            BoostedAscent(false);
        }
    }
}
