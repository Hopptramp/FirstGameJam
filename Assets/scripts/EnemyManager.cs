using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

    public GameObject derpyShooterRef;
    public GameObject trackShooterRef;

    private GameObject derpyShooter;
    private GameObject trackShooter;

    Vector3 startPositionDerpy;
    Vector3 startPositionTrack;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void initialiseEnemies()
    {
        derpyShooter = (GameObject)Instantiate(derpyShooterRef, startPositionDerpy, gameObject.transform.rotation);
        trackShooter = (GameObject)Instantiate(trackShooterRef, startPositionTrack, gameObject.transform.rotation);
    }

    public void setDerpyShooterPosition(Vector3 newPosition)
    {
        startPositionDerpy = newPosition;
    }

    public void setTrackShooterPosition(Vector3 newPosition)
    {
        startPositionTrack = newPosition;
    }

    public void destroyEnemies()
    {
        Destroy(derpyShooter);
        Destroy(trackShooter);
    }
}
