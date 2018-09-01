using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

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

    }

    /**
    * Called by player when it shoots something
    * @param hitInfo The information of the object it shot
    */
    public void PlayerShotObject(RaycastHit hitInfo)
    {
        Debug.Log(hitInfo.collider.name);
    }
  
    public void CharacterAttacked()
    {
        playerHealth -= 1;
        Debug.Log("LMAO");
    }
    
    public void EnemyDestroyed()
    {
        playerScore += 10;
    }
}
