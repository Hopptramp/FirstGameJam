using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraScript : MonoBehaviour {
    
    public Camera gameCamera;
    public float speed;
    Vector3 newPosition;
	public float avgHeight;
    public float avgPercentage;
    public Transform offset;

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
        bool isHigh = false;
        int ID = 0;
        for (int i = 0; i < players.Count; ++i)
        {
            temp += players[i].transform.position.y;
            if (players[i].transform.position.y > offset.position.y)
            {
                isHigh = true;
                ID = i;
            }
        }


        avgHeight = temp / players.Count;
        avgPercentage = Mathf.InverseLerp(0, 480, avgHeight);


        Vector3 newPosition = new Vector3(0, speed, 0);
        transform.parent.Translate(newPosition * Time.deltaTime);

        if (isHigh)
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, players[ID].transform.position.y, transform.position.z), 0.01f);

    }

    void setSpeed(float newSpeed)
    {
        speed = newSpeed;
    }


}
