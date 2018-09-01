using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public const int maxHealth = 100;
	public int currentHealth = maxHealth;
	public int bullets = 5
	bool isDead
	bool hurt
	
	void Update ()
	{
		if(hurt)
		{
		 
		}
	}
	
	public void  onHit(int amount)
	{
		currentHealth -= amount;
		if(currentHealth <= 0 && !isDead)
		{
			currentHealth = 0;
			
			//change on creation of death state
			Death();
		}
	}
	public void onPickup int amount){
		currentHealth += ammount;
		if(currentHealth >= maxHealth)
		{
			currentHealth = maxHealth;
		}
	}
	void Death () {
		isDead = true;
		Debug.Log("YOU ARE DEAD");
	}
}
