using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	[SerializeField] float ascentSpeed = 0.25f;
	[SerializeField] float leanSpeed = 10.0f;
	[SerializeField] float dropSpeed = -2.0f;
	[SerializeField] float fallSpeed = -10.0f;
	[SerializeField] float boostedAscendSpeed = 5.0f;
	[SerializeField] float fallTime = 0.5f;

	//bool doAscend = true;
	bool doBoost = false;

	public bool playerOne = true; // Set as false from scene manager for player 2 when instantiating

	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey(playerOne ? KeyCode.W : KeyCode.I))
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
	}

	void AllowAscent()
	{
		//doAscend = true;
		rb.gravityScale = 0.25f; // set back to default gravity scale
	}

	void ConstantAscent()
	{
		//rb.AddForce (new Vector2 (0, ascentSpeed));
		rb.velocity = new Vector2(rb.velocity.x, ascentSpeed);
	}

	void LeanDirection(float input)
	{
		rb.AddForce ( new Vector2(input * leanSpeed, 0));
	}

	void Drop()
	{
		rb.AddForce(new Vector2(0, dropSpeed));
		rb.gravityScale = 1;
		Invoke ("AllowAscent", fallTime);
	}

	public void BoostedAscent(bool active)
	{
		if (active) {
			rb.AddForce (new Vector2 (rb.velocity.x, boostedAscendSpeed));
			//doAscend = false;
			doBoost = true;
		} else {
			//doAscend = true;
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

    void OnTriggerExit2D(Collider2D _collider)
    {
        if (_collider.gameObject.tag == "RayOfLight")
        {
            BoostedAscent(false);
        }
    }
}
