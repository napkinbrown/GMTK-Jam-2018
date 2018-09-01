using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camMoveScript : MonoBehaviour {

	// Transforms to act as start and end markers for the journey.
        public Transform cp1;
        public Transform cp2;
        public Transform cp3;

        // Movement speed in units/sec.
        public float speed = 5.0F;
        public float rotateSpeed = 0.1F;

        // Time when the movement started.
        private float startTime;

        // Total distance between the markers.
        private float journeyLength;

        private bool newJourney = true;

        void Start()
        {
            transform.LookAt(cp2.position);
            // Keep a note of the time the movement started.
            startTime = Time.time;

            // Calculate the journey length.
            journeyLength = Vector3.Distance(cp1.position, cp2.position);
            
        }
        
        
        // Turns the camera to p1 after reaching a certain distance away 
        // from the destination checkpoint
        void Move(Transform point1, Transform point2, float distance) {

             float step = speed * Time.deltaTime;

            // Move our position a step closer to the target.
            transform.position = Vector3.MoveTowards(transform.position, point2.position, step);

            if ((point2.position - transform.position).magnitude <= distance) {

                //create rotation
                Quaternion wantedRotation = point2.transform.rotation;
    
                //then rotate
                transform.rotation = Quaternion.Lerp(transform.rotation, wantedRotation, Time.deltaTime * rotateSpeed);
            
            }
        }



        // Follows the target position like with a spring
        void Update()
        {
            if (newJourney) {
                // Keep a note of the time the movement started.
                startTime = Time.time;

                // Calculate the journey length.
                journeyLength = Vector3.Distance(cp1.position, cp2.position);
                newJourney = false;
            }
            //Change to be triggered during a specific event
            if (Input.GetKey(KeyCode.F))
            {
                //Checkpoint 1 to checkpoint 2
    
                Move(cp1, cp2, 1);
            }
            if (Input.GetKey(KeyCode.G)) {
                Move(cp2, cp3, 1);
            }
        
           
        }
}
