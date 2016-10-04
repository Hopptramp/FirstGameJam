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
    public Canvas gameOverCanvasPrefab;

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
            PlayerPrefs.SetInt("State", 0);
            m_state = STATE.PLAY;
        }
        else if (Application.loadedLevel == 1)
        {
            PlayerPrefs.SetInt("State", 0);
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
        }

        if (Application.loadedLevel != 2)
        {
            if (m_state == STATE.WIN1)
            {
                PlayerPrefs.SetInt("State", 1);
                Application.LoadLevel(2);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Application.LoadLevel(0);
            }
        }

        if (Application.loadedLevel != 3)
        {
            if (m_state == STATE.WIN2)
            {
                PlayerPrefs.SetInt("State", 2);
                Application.LoadLevel(3);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Application.LoadLevel(0);
            }
        }
    }
}
