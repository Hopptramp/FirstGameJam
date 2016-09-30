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

			if (other.tag == "Bullet") 
			{
				Destroy (other.gameObject);
			} 
				
			Debug.Log ("Player entered destroy collider");
				//kill player

		}

		if (gameObject.tag == "VictoryCollider") 
		{
			Debug.Log ("Player entered victory collider");
			//victory to player
		}
			
	}

}
