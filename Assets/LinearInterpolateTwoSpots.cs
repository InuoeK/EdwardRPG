using UnityEngine;
using System.Collections;

public class LinearInterpolateTwoSpots : MonoBehaviour {

	public Vector3 lerpToHere;
	
	// Update is called once per frame
	void Update () {
		lerp ();
	}

	void lerp()
	{	

		this.transform.position = Vector3.Lerp (this.transform.position,
		                                        lerpToHere,
		                                        Time.deltaTime);
	}
}
