using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public int playerScore;
    public int playerHealth;

	// Use this for initialization
	void Start () {
        playerHealth = 4;
        playerScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
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
