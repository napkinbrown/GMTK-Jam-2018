using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairScript : MonoBehaviour {

    private Transform Player;

    bool isAimed;
    Transform crosshairPosition;

    // Use this for initialization
    void Start () {
        isAimed = false;
    }

    public void AimedAtCamera() {
        isAimed = true;
    }

    public void AimedAwayFromCamera() {
        isAimed = false;
    }
    
    // Update is called once per frame
    void Update () {
        
        
        if (isAimed) {
            //Player = GameObject.FindWithTag("MainCamera").transform;
            //this.transform.LookAt(Player);
        } else {
            //this.enabled = false;
        }
     
    }
}