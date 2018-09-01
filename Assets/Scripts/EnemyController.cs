using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public int enemyHealth;
    public Transform Player;
    int MoveSpeed = 4;
    int MaxDist = 10;
    int MinDist = 1;
    // Use this for initialization
    void Start () {
        enemyHealth = 4;
    }

    // Update is called once per frame
    void Update() {
        Debug.Log(Time.time);

        if (Time.time > 30f)
        {
            Destroy(this.gameObject);
        }
        //Check if enemy health is greater than 0, if so update movement.
        //If not, then update player score and destroy this enemy.
        if (enemyHealth > 0) { 
            Player = GameObject.FindWithTag("Player").transform;
            this.transform.LookAt(Player);

            if (Vector3.Distance(this.transform.position, Player.position) >= MinDist)
            {
                if (Vector3.Distance(this.transform.position, Player.position) <= MaxDist)
                {
                    //Here Call any function U want Like Shoot at here or something
                    this.transform.position += this.transform.forward * MoveSpeed * Time.deltaTime;
                }
            }
            else
            {
                //Update player score
                Destroy(this.gameObject);
            }
        }
    }
}

