﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject cameraManager;

    public static GameManager instance = null;
  
	  public int playerScore;
    public int playerHealth;
  
    private void Awake()
    {
        // Singleton
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
      
        playerHealth = 4;
        playerScore = 0;
    }
	
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.F))
                cameraManager.GetComponent<CameraManager>().MoveToNextCheckpoint();
    }

    /**
    * Called by player when it shoots something
    * @param hitInfo The information of the object it shot
    */
    public void PlayerShotObject(RaycastHit hitInfo)
    {
        Debug.Log(hitInfo.collider.name);
    }


    /**
     * THIS IS A PLACEHOLDER FUNCTION
     * 
     */
    public void PlayerIsReloading()
    {
        Debug.Log("Reloading... (Replace me with UI animations eventually)");
    }

    public void PlayerIsDoneReloading()
    {
        Debug.Log("Done! (Replace me with UI animations eventually)");
    }
  
    public void CharacterAttacked()
    {
        playerHealth -= 1;
    }
    
    public void EnemyDestroyed()
    {
        playerScore += 10;
    }
}
