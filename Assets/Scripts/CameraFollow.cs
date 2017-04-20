using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Camera camera;

    Vector3 selfieStick;

	// Use this for initialization
	void Start () {
		if(camera == null) {
            camera = FindObjectOfType<Camera>();
        }

        selfieStick = camera.transform.position - this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        camera.transform.position = Vector3.Lerp(camera.transform.position, this.transform.position + selfieStick, Time.deltaTime * 5);
	}
}
