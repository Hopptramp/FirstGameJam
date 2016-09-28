using UnityEngine;
using System.Collections;

public class GUIScript : MonoBehaviour {

	int score = 0;
	float time = 0.0f;

	bool climbing = true;
	bool paused = false;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//if the current state is play, do this
		//{
			if (Input.GetKey (KeyCode.Space)) {
				climbing = false;
				print ("climbing now false");
			}

			if (Input.GetKey (KeyCode.X)) {
				climbing = true;
				print ("climbing now true");
			}

			ScoreCounter ();

			TimeTracker ();
		//}
	}

	void OnGUI()
	{
		//if the state is play, do this
		//{
			GUI.Box (new Rect (10, 10, 150, 25), new GUIContent ("Current Score is " + score));
			GUI.Box (new Rect (Screen.width - 160, 10, 150, 25), new GUIContent ("Time: " + time.ToString ("F2")));
		//}
	}

	void ScoreCounter()
	{
		if (climbing == true) {
			score++;
		} else {
			score--;
		}
	}

	void TimeTracker()
	{
		if (!paused) {
			time += Time.deltaTime;
		}
	}
}
