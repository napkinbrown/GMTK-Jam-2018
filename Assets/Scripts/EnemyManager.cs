using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    private List<GameObject> enemyCheckpoints;
    private List<GameObject> enemies;

	// Use this for initialization
	void Start () { 
        for (int i = 0; i < this.transform.childCount; i++)
        {
            GameObject child = this.transform.GetChild(i).gameObject;
            if (child.tag == "Enemies")
                enemies = getListOfChildren(child);
            if (child.tag == "EnemyCheckpointList")
                enemyCheckpoints = getListOfChildren(child);
        }
    }

    private List<GameObject> getListOfChildren(GameObject child) {
        List<GameObject> listOfChildren = new List<GameObject>();
        for (int i = 0; i < child.transform.childCount; i++)
        {
            listOfChildren.Add(child.transform.GetChild(i).gameObject);
        }

        return listOfChildren;
    }

}
