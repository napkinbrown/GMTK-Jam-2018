using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
  
    public const int maxHealth = 100;
    public int currentHealth;
	public int currentBullets = 5;
	bool isDead;
	bool isHurt;
	public Text healthText;
	public Text bulletText;
 
    public GameObject cameraManager;

    public static GameManager instance = null;
    public int playerScore;
  
    private void Awake()
    {
        // Singleton
        if (instance == null)
          instance = this;
        else
          Destroy(gameObject);

        currentHealth = maxHealth;
        playerScore = 0;

        currentBullets = PlayerController.initialBullets;

        updateHUD();
    }
    
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.F))
                cameraManager.GetComponent<CameraManager>().MoveToNextCheckpoint();
    }

    public void updateHUD()
    {
        if (currentBullets <= 0)
            bulletText.text = "R";
        else
            bulletText.text = "" + currentBullets;

        healthText.text = "" + currentHealth;
    }

    public void onHit(int amount){
		currentHealth -= amount;
		if(currentHealth <= 0)
		{
			currentHealth = 0;
			//change on creation of death state
			Death();
		}
	}
  
	public void onPickup(int amount){
		currentHealth += amount;
		if(currentHealth >= maxHealth)
		{
			currentHealth = maxHealth;
		}
	}
    
	void Death () {
		isDead = true;
		Debug.Log("YOU ARE DEAD");
    }
    
    /**
    * Called by player when it shoots something
    * @param hitInfo The information of the object it shot
    * @param currentAmmo The amount of ammo the player currently has
    */
    public void PlayerShotObject(RaycastHit hitInfo, int currentAmmo)
    {
        this.currentBullets = currentAmmo;

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

        updateHUD();
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
        currentBullets = PlayerController.initialBullets;
        updateHUD();
    }
  
    public void CharacterAttacked()
    {
        if (currentHealth > 0) {
            currentHealth -= 1;
            cameraManager.GetComponent<CameraManager>().CameraHit();
        } else {
            //Load death screen
        }
    }
    
    public void EnemyDestroyed()
    {
        playerScore += 10;
    }

}
