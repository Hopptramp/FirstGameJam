using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

    public GameObject m_gameManager;
    private GameManager m_gameManagerScript;

	// Use this for initialization
	void Awake ()
    {
        m_gameManagerScript = m_gameManager.GetComponent<GameManager>();
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
            else if (other.tag == "Player")
            {
                m_gameManagerScript.m_state = GameManager.STATE.GAMEOVER;
                Debug.Log("Player entered destroy collider");
            }
			
            	
			
				//kill player

		}

		if (gameObject.tag == "VictoryCollider") 
		{
			Debug.Log ("Player entered victory collider");
			//victory to player
		}
			
	}

}
