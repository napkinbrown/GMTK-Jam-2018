using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float walkSpeed = 2;
    public float strafeSpeed = 2;
    public float mouseSensitivity = 30;
	
	// Update is called once per frame
	void Update () {
        /* Mouse movement */
        this.transform.Rotate(0, Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.deltaTime, 0);

        Vector3 walkVector = Vector3.zero;

        /* Keyboard controlls */
        if (Input.GetKey(KeyCode.W))
        {
            walkVector += new Vector3(walkSpeed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            walkVector += new Vector3(-walkSpeed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            walkVector += new Vector3(0, 0, strafeSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            walkVector += new Vector3(0, 0, -strafeSpeed * Time.deltaTime);
        }

        this.transform.Translate(walkVector, Space.Self);
    }
}
