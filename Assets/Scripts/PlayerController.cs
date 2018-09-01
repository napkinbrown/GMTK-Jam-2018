using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float walkSpeed = 2;
    public float strafeSpeed = 2;
    public float mouseSensitivity = 30;

    public float reloadForSeconds;

    public int initialBullets = 6;
    private int currentBullets
    {
        get; set;
    }

    private bool reloading = false;

    private GameManager gm;
    public Transform gunPosition;

    void Start()
    {
        GameObject gmObject = GameObject.FindGameObjectWithTag("GameManager");
        if (gmObject != null)
            gm = gmObject.GetComponent<GameManager>();
        else
            Debug.LogError("Could not find Game Manager!", this);

        gunPosition = GetComponentInChildren<Transform>();
        currentBullets = initialBullets;
    }

    void Update ()
    {
        /*
         * 
         * Mouse movement 
         * 
         */
        this.transform.Rotate(0, Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.deltaTime, 0);

        /* 
         * 
         * Keyboard controlls 
         * 
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
         * 
         * Firing
         * 
         */
        if (Input.GetButtonDown("Fire1"))
        {
            if (currentBullets > 0)
                FireGun();
            else if (!reloading) {
                StartCoroutine("Reload");
            }
        }
    }

    private void FireGun()
    {
        currentBullets--;
        Debug.Log(currentBullets);

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

    IEnumerator Reload() {
        reloading = true;
        while (true)
        {
            gm.PlayerIsReloading();
            yield return new WaitForSeconds(reloadForSeconds);
            gm.PlayerIsDoneReloading();

            currentBullets = initialBullets;
            reloading = false;
            break;
        }
    }
}
