using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    private void Awake()
    {
        // Singleton
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayerShotObject(RaycastHit hitInfo)
    {
        Debug.Log(hitInfo.collider.name);
    }
}
