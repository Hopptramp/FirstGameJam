using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log ("Trigger Entered");

		if (gameObject.tag == "DeathCollider") 
		{
			Debug.Log ("Player entered destroy collider");
			//kill the player
		}

		if (gameObject.tag == "VictoryCollider") 
		{
			Debug.Log ("Player entered victory collider");
			//enter victory state
		}
			
	}
}
