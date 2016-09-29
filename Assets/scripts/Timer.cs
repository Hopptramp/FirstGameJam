using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour
{
    float timeRemaining = 60.0f;

    void Update()
    {
        timeRemaining -= Time.deltaTime;
    }

    void OnGUI()
    {
        GUI.color = Color.black;
        if (timeRemaining > 0)
        {
            GUI.Label(new Rect(500, 35, 200, 100), "Time Remaining : " + (int)timeRemaining);
        }
        else
        {
            GUI.Label(new Rect(500, 35, 200, 100), "Time's Up");
        }
    }
}
