using UnityEngine;
using System.Collections;

public class GUIScript : MonoBehaviour
{

    int score = 0;
    float time = 0.0f;

    bool climbing = true;
    bool paused = false;

    StateMachine sm;
    GameObject gameManager;

    //error just cause

    // Use this for initialization
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController");
        sm = gameManager.gameObject.GetComponent<StateMachine>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sm.currentState == StateMachine.State.Play)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                climbing = false;
                print("climbing now false");
            }

            if (Input.GetKey(KeyCode.X))
            {
                climbing = true;
                print("climbing now true");
            }

            ScoreCounter();

            TimeTracker();
        }
    }

    void OnGUI()
    {
        if (sm.currentState == StateMachine.State.Play)
        {
            GUI.Box(new Rect(10, 10, 150, 25), new GUIContent("Current Score is " + score));
            GUI.Box(new Rect(Screen.width - 160, 10, 150, 25), new GUIContent("Time: " + time.ToString("F2")));
        }
    }

    void ScoreCounter()
    {
        if (climbing == true)
        {
            score++;
        }
        else
        {
            score--;
        }
    }

    void TimeTracker()
    {
        if (!paused)
        {
            time += Time.deltaTime;
        }
    }
}