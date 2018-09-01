using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public const int maxHealth = 100;
	public int currentHealth = maxHealth;
	public int bullets = 5;
	bool isDead;
	bool hurt;
	public Text printHealth;
	public Text printBullets;
	
	void Awake (){
		
	}
	void Update ()
	{
		printBullets.text = "" + bullets;
		printHealth.text = "" + currentHealth;
		if(hurt)
		{
		 
		}
	}
	
	//take out later
	public void onFir(int amount) {
		bullets -=amount;
		if(bullets <=0){
			Debug.Log("Reload");
			bullets = 5;
		}
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
}
