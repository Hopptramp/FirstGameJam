using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [Serializable]
    public enum STATE
    {
        PLAY = 0,
        WIN1 = 1,
        WIN2 = 2
    };

    public LevelManager levelScript;
    public STATE m_state;
    public int winScore = 3;
	public Text player1Score;
	public Text player2Score;

    //private int level = 3;

	// Use this for initialization
	void Awake ()
    {
        if (Application.loadedLevel == 0)
        {
            ResetPlayerPrefs();
            m_state = STATE.PLAY;
        }
        else if (Application.loadedLevel == 1)
        {
            levelScript = GetComponent<LevelManager>();
            InitGame();
        }
    }

    void InitGame()
    {
        levelScript.SetupScene();
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.loadedLevel == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Application.LoadLevel(1);
            }

			if (Input.GetKeyDown (KeyCode.Return)) 
			{
				Application.LoadLevel(4);
			}

            if(Input.GetKeyDown(KeyCode.Y))
            {
                PlayerPrefs.SetInt("HardMode", 1);
            }
        }

        if (Application.loadedLevel != 2)
        {
            if (m_state == STATE.WIN1)
            {
                if (PlayerPrefs.GetInt("Player1Score") == winScore - 1)
                {
                    PlayerPrefs.SetInt("State", 1);
                    Application.LoadLevel(2);
                }
                else
                {
                    PlayerPrefs.SetInt("Player1Score", PlayerPrefs.GetInt("Player1Score") + 1);
                    Application.LoadLevel(1);
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
				ResetPlayerPrefs();
                Application.LoadLevel(1);
            }

			if (Input.GetKeyDown (KeyCode.Return)) 
			{
				ResetPlayerPrefs();
				Application.LoadLevel(0);
			}
        }

		if (Application.loadedLevel == 1) 
		{
			player1Score.text = "Player 1 Score: " + PlayerPrefs.GetInt ("Player1Score").ToString (); 
			player2Score.text = "Player 2 Score: " + PlayerPrefs.GetInt ("Player2Score").ToString (); 
		}

        if (Application.loadedLevel != 3)
        {
            if (m_state == STATE.WIN2)
            {
                if (PlayerPrefs.GetInt("Player2Score") == winScore - 1)
                {
                    PlayerPrefs.SetInt("State", 2);
                    Application.LoadLevel(3);
                }
                else
                {
                    PlayerPrefs.SetInt("Player2Score", PlayerPrefs.GetInt("Player2Score") + 1);
                    Application.LoadLevel(1);
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
				ResetPlayerPrefs();
                Application.LoadLevel(1);
            }

			if (Input.GetKeyDown (KeyCode.Return)) 
			{
				ResetPlayerPrefs();
				Application.LoadLevel(0);
			}
        }

		if (Application.loadedLevel == 4) 
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				Application.LoadLevel(1);
			}
		}
    }

    void ResetPlayerPrefs()
    {
        if (!PlayerPrefs.HasKey("State"))
        {
            PlayerPrefs.DeleteKey("State");
        }
        if (!PlayerPrefs.HasKey("Player1Score"))
        {
            PlayerPrefs.DeleteKey("Player1Score");
        }
        if (!PlayerPrefs.HasKey("Player2Score"))
        {
            PlayerPrefs.DeleteKey("Player2Score");
        }
        if (!PlayerPrefs.HasKey("HardMode"))
        {
            PlayerPrefs.DeleteKey("HardMode");
        }


        PlayerPrefs.SetInt("State", 0);
        PlayerPrefs.SetInt("Player1Score", 0);
        PlayerPrefs.SetInt("Player2Score", 0);
        PlayerPrefs.SetInt("HardMode", 0);
    }
}
