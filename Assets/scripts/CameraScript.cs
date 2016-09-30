using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
    
    public Camera gameCamera;
    private float speed;
    Vector3 newPosition;

    // Use this for initialization
    void Start ()
    {
        setSpeed(1.0f);
        gameCamera.orthographic = true;
	}
	
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
