﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public int enemyHealth;
    public Transform Player;
    public int MoveSpeed = 4;
    public int MaxDist = 100;
    public int MinDist = 1;
    public float fireRate = 1.5F;
    private float nextFire = 0.0F;
    public int AttackDist = 2;
    public GameManager gameManager;
    public GameObject gObj;
    private SpriteRenderer spRndrer;

    // Use this for initialization
    void Start () {
        enemyHealth = 4;
        gObj = GameObject.FindWithTag("GameManager");
        gameManager = gObj.GetComponent<GameManager>();
        spRndrer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() { 

        //Check if enemy health is greater than 0, if so update movement.
        //If not, then update player score and destroy this enemy.
        if (enemyHealth > 0)
        {
            Player = GameObject.FindWithTag("MainCamera").transform;
            this.transform.LookAt(Player);

            if (Vector3.Distance(this.transform.position, Player.position) >= MinDist)
            {
                if (Vector3.Distance(this.transform.position, Player.position) <= MaxDist)
                {
                    //Here Call any function U want Like Shoot at here or something
                    this.transform.position += this.transform.forward * MoveSpeed * Time.deltaTime;
                }
            }

            //Attack player if close enough
            if ((Vector3.Distance(this.transform.position, Player.position) <= AttackDist) && (Time.time > nextFire))
            {
                nextFire = Time.time + fireRate;
                gameManager.CharacterAttacked();
            }
        }
        else
        {
            Debug.Log("UHHG im dead jay");
            //Needs: Update player score and play Death sound
            StartCoroutine(EnemyDeathFlash(0.1f));
            gameManager.EnemyDestroyed();
            //Destroy(this.gameObject);
        }
        
    }

    //Simple function to update the current enemy's health
    public void EnemyTakeDamage()
    {
        enemyHealth -= 1;
    }

    public IEnumerator EnemyDeathFlash(float x)
    {
        for (int i = 0; i < 10; i++)
        {
            spRndrer.enabled = false;
            yield return new WaitForSeconds(x);
            spRndrer.enabled = true;
            yield return new WaitForSeconds(x);

            Debug.Log(spRndrer + " lol " + i);
        }
    }
}

