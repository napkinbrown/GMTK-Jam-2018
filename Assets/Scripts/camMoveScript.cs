
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camMoveScript : MonoBehaviour {

	// Transforms to act as start and end markers for the journey.
        private Transform nextPoint;

        public GameObject bloodImage;

        // Movement speed in units/sec.
        public float speed = 5.0F;
        public float rotateSpeed = 0.1F;

        private bool getDamage;
        private Color color;

        void Start()
        {
            nextPoint = GameObject.Find("Checkpoint 1").transform;
            transform.LookAt(nextPoint.position);
            color = bloodImage.GetComponent<Renderer>().material.color;
        }
        
        public void SetNextPoint(Transform checkpoint) {
            Debug.Log("Cam: Setting next point to " + checkpoint.name);
            nextPoint = checkpoint;
        }

        public void RedFlash() {

            getDamage = true;

            StartCoroutine(Wait());

        }

        public IEnumerator Wait() {

            yield return new WaitForSeconds(2);
    
            getDamage = false;

        }

        // Follows the target position like with a spring
        void Update()
        {
            if (nextPoint == null)
                return;
            float step = speed * Time.deltaTime;

            // Move our position a step closer to the target.
            transform.position = Vector3.MoveTowards(transform.position, nextPoint.position, step);

            if ((nextPoint.position - transform.position).magnitude <= 1) {

                //create rotation
                Quaternion wantedRotation = nextPoint.transform.rotation;
    
                //then rotate
                transform.rotation = Quaternion.Lerp(transform.rotation, wantedRotation, Time.deltaTime * rotateSpeed);
            
            }
        
           if (getDamage)
         {
            bloodImage.SetActive(true);
            
            color.a -= 20f;
            bloodImage.GetComponent<Renderer>().material.color -= new Color(0,0,0,.10f);
         }
         if (!getDamage)
         {
            //bloodImage.SetActive(false);
         }
        }
}

