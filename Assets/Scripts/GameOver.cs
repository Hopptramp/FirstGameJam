using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	public GameObject hell;
	public GameObject heaven;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("Trigger Entered");

		if (other.tag == "DeathCollider") {

			if (other.tag == "Bullet") 
			{
				Destroy (other.gameObject);
			} 

			if (other.tag == "Player") 
			{
				Debug.Log ("Player entered destroy collider");
				//kill player
			}

		}

		if (other.tag == "VictoryCollider") 
		{

			if (other.tag == "Player") 
			{
				Debug.Log ("Player entered victory collider");
				//victory to player
			}

		}
	}
}
