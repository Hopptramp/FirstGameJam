using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public LevelManager levelScript;

    //private int level = 3;

	// Use this for initialization
	void Awake () {
        levelScript = GetComponent<LevelManager>();
        InitGame();
	}

    void InitGame()
    {
        levelScript.SetupScene();
    }

	// Update is called once per frame
	void Update () {
	
	}
}
