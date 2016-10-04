using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraScript : MonoBehaviour {
    
    public Camera gameCamera;
    public float speed;
    Vector3 newPosition;
	public float avgHeight;
    public float avgPercentage;

	List<GameObject> players;

	void Start()
	{
		
	}

	public void AddToList(GameObject player)
	{
        if(players == null)
            players = new List<GameObject>();
        players.Add (player);
	}
	
	// Update is called once per frame
	void Update ()
    {
		float temp = 0;
		for (int i = 0; i < players.Count; ++i) {
			temp += players [i].transform.position.y;
		}

		avgHeight = temp / players.Count;
        avgPercentage = Mathf.InverseLerp(0, 480, avgHeight);


		if (!GetComponent<ScreenShake> ().isShaking) {
			Vector3 newPosition = new Vector3 (0, speed, 0);
			transform.Translate (newPosition * Time.deltaTime);

			if (avgHeight > transform.position.y + 10)
				transform.position = Vector3.Lerp (transform.position, new Vector3 (transform.position.x, avgHeight, transform.position.z), 0.01f);
		}
	}

    void setSpeed(float newSpeed)
    {
        speed = newSpeed;
    }


}
