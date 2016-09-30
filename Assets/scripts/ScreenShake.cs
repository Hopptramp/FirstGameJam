using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour {

	float shakeAmt;
	Camera mainCamera;
	Vector3 originalCameraPosition;

	[SerializeField] float testShakeStrength = 0.2f;
	[SerializeField] float shakeDuration = 0.3f;

	void Start()
	{
		mainCamera = GetComponent<Camera> ();
		
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.T))
			ShakeScreen (testShakeStrength);
	}

	public void ShakeScreen(float? shakeSize)
	{
		shakeAmt = shakeSize.HasValue ? (float)shakeSize : testShakeStrength;
		InvokeRepeating ("CameraShake", 0, .01f);
		Invoke ("StopShaking", shakeDuration);
	}

	void CameraShake()
	{
		if(shakeAmt>0) 
		{
			Vector2 quakeAmt = Random.insideUnitSphere * shakeAmt;
			Vector3 pp = mainCamera.transform.position;
			pp.x += quakeAmt.x; 
			pp.y += quakeAmt.y;  
			mainCamera.transform.position = pp;
		}
	}

	void StopShaking()
	{
		CancelInvoke("CameraShake");
		mainCamera.transform.localPosition = Vector3.Lerp(mainCamera.transform.localPosition, new Vector3(0,0,-20), 1);
	}

}