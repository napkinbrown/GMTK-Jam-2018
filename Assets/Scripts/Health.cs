using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health {
	public const int maxHealth = 100;
	public int currentHealth = maxHealth;
	// Use this for initialization

	public void  Onhit(int amount)
	{
		currentHealth -= amount;
		if(currentHealth <= 0)
		{
			currentHealth = 0;
			Debug.Log("YOU ARE DEAD");
			//change on creation of death state
		}
	}
	// Update is called once per frame
	
}
public int currentHealth;
	public Health;
	public Text text;
	
	
	void Awake(){
		var currentHealth = GetComponet<Health>();
		text = GetComponent <Text>();
		text.text = "HP: " + currentHealth;
		Health = new Health()
	}
	// Update is called once per frame
	void Update () {
		
	}
