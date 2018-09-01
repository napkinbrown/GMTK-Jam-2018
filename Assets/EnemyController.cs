using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public float movementSpeed;
    public Transform Player;
    int MoveSpeed = 4;
    int MaxDist = 10;
    int MinDist = 1;
    // Use this for initialization
    void Start () {

        movementSpeed = 5;
}
	
	// Update is called once per frame
	void Update () {
        Player = GameObject.FindWithTag("MainCamera").transform;
        this.transform.LookAt(Player);

        if (Vector3.Distance(this.transform.position, Player.position) >= MinDist)
        {
            this.transform.position += this.transform.forward * MoveSpeed * Time.deltaTime;

            if (Vector3.Distance(this.transform.position, Player.position) <= MaxDist)
            {
                //Here Call any function U want Like Shoot at here or something
            }
        }
    }
}

