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
        if (timeRemaining > 0)
        {
            GUI.Label(new Rect(400, 0, 200, 100), "Time Remaining : " + (int)timeRemaining);
        }
        else
        {
            GUI.Label(new Rect(400, 0, 200, 100), "Time's Up");
        }
    }
}
