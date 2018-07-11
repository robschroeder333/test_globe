using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FP_Controller : MonoBehaviour {
        public Transform camTran;
        [Range(1,100)]
        public float moveSpeed = 20.0f;
        [Range(1,100)]
        public float lookSpeedX = 70.0f;
        [Range(1,100)]
        public float lookSpeedY = 50.0f;
        public bool invertY = false;
        private Vector3 moveDirection;
        private Vector2 mouseDelta;
        // Use this for initialization
        void Start () {
                camTran = transform.Find("FP_Camera");
        }

        // Update is called once per frame
        void Update () {
                moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
                mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        }
        /// <summary>
        /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
        /// </summary>
        void FixedUpdate()
        {
                if (!invertY) 
                {
                     mouseDelta.y = -mouseDelta.y;   
                }
                GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveDirection * moveSpeed / 100));
                GetComponent<Rigidbody>().transform.Rotate(0, mouseDelta.x * lookSpeedX / 50, 0);
                camTran.transform.Rotate(mouseDelta.y * lookSpeedY / 50, 0, 0);

        }
}