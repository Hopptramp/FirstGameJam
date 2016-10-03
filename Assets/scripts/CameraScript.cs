using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
    
    public Camera gameCamera;
    public float speed;
    Vector3 newPosition;

	
	// Update is called once per frame
	void Update ()
    {
        Vector3 newPosition = new Vector3(0, getSpeed(), 0);
        gameCamera.transform.Translate(newPosition * Time.deltaTime);
	}

    void setSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    float getSpeed()
    {
        return speed;
    }
}
