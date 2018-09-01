using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float walkSpeed = 2;
    public float strafeSpeed = 2;
    public float mouseSensitivity = 30;

    public GameManager gm;
    public Transform gunPosition;

    void Start()
    {
        GameObject gmObject = GetComponent<GameObject>();
        if (gmObject == null)
            // This throws an error for some reason, but it works alright
            gm = gmObject.GetComponent<GameManager>();
        else
            Debug.LogError("Could not find Game Manager!", this);

        gunPosition = GetComponent<Transform>();
    }

    void Update ()
    {
        /*
         * Mouse movement 
         */
        this.transform.Rotate(0, Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.deltaTime, 0);

        /* 
         * Keyboard controlls 
         */
        Vector3 walkVector = Vector3.zero;
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

        /*
         * Firing
         */
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hitInfo;

            float gunRotation = gunPosition.rotation.eulerAngles.y; //In degrees
            float xComponent = Mathf.Cos(gunRotation * Mathf.Deg2Rad);
            float zComponent = Mathf.Sin(gunRotation * Mathf.Deg2Rad);
            Vector3 direction = new Vector3(xComponent, 0, zComponent);

            // Layer mask determines what gets hit. Here i'm telling it to hit everything except the Player layer
            // It uses bitshifting, which is a weird way to do it, but w/e
            int layerMask = 1 << 8;
            layerMask = ~layerMask;

            Physics.Raycast(gunPosition.position, direction, out hitInfo, Mathf.Infinity, layerMask, QueryTriggerInteraction.Collide);

            if (hitInfo.collider != null)
            {
                gm.PlayerShotObject(hitInfo);
            }
        }
    }
}
