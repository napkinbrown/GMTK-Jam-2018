using System.Collections;
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
    * @param currentAmmo The amount of ammo the player currently has
    */
    public void PlayerShotObject(RaycastHit hitInfo, int currentAmmo)
    {
        Debug.Log(hitInfo.collider.name);
        GameObject hitObject = GameObject.Find(hitInfo.collider.name);
        if (hitObject.tag == "EnemyObject")
        {
           EnemyController enemy = hitObject.GetComponent<EnemyController>();
            enemy.EnemyTakeDamage();

        }
        if (hitObject.tag == "MainCamera") {
            Debug.Log("Don't shoot the camera man!");
            CharacterAttacked();
        }
        //GameObject gmObject = GameObject.FindGameObjectWithTag("GameManager");
    }


    /**
     * THIS IS A PLACEHOLDER FUNCTION
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
        if (playerHealth > 0)
            playerHealth -= 1;
        else {
            //Load death screen
        }
    }
    
    public void EnemyDestroyed()
    {
        playerScore += 10;
    }
}
