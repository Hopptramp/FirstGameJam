using UnityEngine;
using System.Collections;

public class TextInteraction : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseEnter()
	{
		//if state is menu
		//{
			GetComponent<Renderer>().material.color = Color.blue;
		//}
	}

	void OnMouseExit()
	{
		//if state is menu
		//{
			GetComponent<Renderer>().material.color = Color.white;
		//}
	}
}
