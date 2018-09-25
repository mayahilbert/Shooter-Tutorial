using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform target; //the position that the camera will be following
	public float smoothing = 5f;
	Vector3 offset;


	// Use this for initialization
	void Start () {
		offset = transform.position - target.position;

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 targetCamPos = target.position + offset;
		transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing);
	}
}
