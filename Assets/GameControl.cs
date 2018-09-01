using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {

    public GameObject cameraManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Follows the target position like with a spring
    void Update() {
           if (Input.GetKeyDown(KeyCode.F))
                cameraManager.GetComponent<CameraManager>().MoveToNextCheckpoint();
    }
}
