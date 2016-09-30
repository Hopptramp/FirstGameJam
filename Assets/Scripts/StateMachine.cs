using UnityEngine;
using System.Collections;

public class StateMachine : MonoBehaviour {

	public enum State {
		Menu,
		Play,
		GameOver
	}

	public State currentState;

	void Start()
	{
		currentState = State.Play;
	}

	void Update()
	{
		if (currentState == State.Menu) {
			//go through the menu sequence
		} else if (currentState == State.Play) {
			//play the main game
		} else if (currentState == State.GameOver) {
			//play game over menu
		}
	}
}
