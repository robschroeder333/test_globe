using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {

        public GravitySource gSource;
        private Transform playerTransform;

        /// <summary>
        /// Start is called on the frame when a script is enabled just before
        /// any of the Update methods is called the first time.
        /// </summary>
        void Start()
        {
                GetComponent<Rigidbody>().useGravity = false;
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                playerTransform = transform;
        }
        /// <summary>
        /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
        /// </summary>
        void FixedUpdate()
        {
                if (gSource)
                {
                        gSource.Attract(playerTransform);
                }
        }
}