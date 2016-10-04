using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

    public GameObject m_gameManager;
    private GameManager m_gameManagerScript;

    public void setup(GameObject _gameManager)
    {
        m_gameManagerScript = _gameManager.GetComponent<GameManager>();
    }

	// Use this for initialization
	void Awake ()
    {
       // m_gameManagerScript = m_gameManager.GetComponent<GameManager>();
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
                Destroy(other.gameObject);
            }
            else if (other.tag == "Player")
            {
                if (other.gameObject.GetComponent<PlayerMovement>().playerOne)
                {
                    m_gameManagerScript.m_state = GameManager.STATE.WIN2;
                }
                else
                {
                    m_gameManagerScript.m_state = GameManager.STATE.WIN1;
                }
            }

		}

		if (gameObject.tag == "VictoryCollider") 
		{
            if (other.gameObject.GetComponent<PlayerMovement>().playerOne)
            {
                m_gameManagerScript.m_state = GameManager.STATE.WIN1;
            }
            else
            {
                m_gameManagerScript.m_state = GameManager.STATE.WIN2;
            }

            GetComponent<AudioSource>().Play();
        }
			
	}

}
