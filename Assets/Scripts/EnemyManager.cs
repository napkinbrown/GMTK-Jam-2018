using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    private List<GameObject> enemyCheckpoints;
    private List<GameObject> enemies;

    // Use this for initialization
    void Start() {
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

    public List<GameObject> getEnemyCheckpoints()
    {
        return enemyCheckpoints;
    }

    public List<GameObject> getEnemies(bool includeDeactivated)
    {
        if (includeDeactivated)
            return enemies;

        List<GameObject> activeEnemies = new List<GameObject>;
        foreach (GameObject enemy in enemies) {
            if (enemy.activeInHierarchy)
                activeEnemies.Add(enemy);
        }

        return activeEnemies;
    }

    public List<GameObject> getEnemies()
    {
        return getEnemies(true);
    }

}
