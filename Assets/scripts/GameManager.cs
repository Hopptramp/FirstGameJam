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
        GAMEOVER = 1,
        Win = 2
    };

    public LevelManager levelScript;
    public STATE m_state;
    public Text gameOverText;

    //private int level = 3;

	// Use this for initialization
	void Awake ()
    {
        if (!PlayerPrefs.HasKey("State"))
        {
            PlayerPrefs.SetInt("State", 0);
        }

        if (Application.loadedLevel == 0)
        {
            Debug.Log(m_state);
            PlayerPrefs.SetInt("State", 0);
            m_state = STATE.PLAY;
        }
        else if (Application.loadedLevel == 1)
        {
            PlayerPrefs.SetInt("State", 0);
            levelScript = GetComponent<LevelManager>();
            InitGame();
        }
        else if (Application.loadedLevel == 2)
        {
            if (PlayerPrefs.GetInt("State") == 2)
            {
                gameOverText.text = "You Win";
            }
            else
            {
                gameOverText.text = "You lose";
            }
            Instantiate(gameOverText, Vector3.zero, Quaternion.identity);
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
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Application.LoadLevel(1);
            }
        }

        if (Application.loadedLevel != 2)
        {
            if (m_state == STATE.GAMEOVER)
            {
                PlayerPrefs.SetInt("State", 1);
                Application.LoadLevel(2);
            }

            if (m_state == STATE.Win)
            {
                PlayerPrefs.SetInt("State", 2);
                Application.LoadLevel(2);
            }
        }
    }
}
