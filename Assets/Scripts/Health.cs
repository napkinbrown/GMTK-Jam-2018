using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
	public const int maxHealth = 100;
	public int currentHealth = maxHealth;
	// Use this for initialization
	void Start () {
		
	}
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
	void Update () {
		
	}
}
