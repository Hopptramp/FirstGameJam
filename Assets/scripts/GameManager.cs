using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public LevelManager levelScript;

    //private int level = 3;

	// Use this for initialization
	void Awake () {
        if(Application.loadedLevel == 1)
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
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Application.LoadLevel(1);
            }
        }
    }
}
