﻿using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using UnityEngine;
using UnityEngine.Experimental.XR;

namespace Player
{
    [System.Serializable]
    public class Boundary //This is the section where you would set the boundary in the scene
    {
        public float xMin, xMax, zMin, zMax; //These are the values you will set for the boundary in the Inspector Pane
    }

    public class PlayerController : MonoBehaviour
    {
        public static PlayerController instance;
        public float speed;
        public Boundary boundary;
        public GameObject shot;
        public Transform shotSpawn;
        public float fireRate;
        public VirtualJoystick moveJoystick;
        private float nextFire;

        private void Awake()
        {
            instance = this;
        }

        void Update()
        {

        }

        void FixedUpdate()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            GetComponent<Rigidbody>().velocity = movement * speed;

            GetComponent<Rigidbody>().position = new Vector3
            (
                Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
                0.0f,
                Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
            );

            if (moveJoystick.InputDirection != Vector3.zero)
            {
                GetComponent<Rigidbody>().velocity = moveJoystick.InputDirection * speed;
            }
        }

        public void FireWeapon()
        {
            if (Time.time > nextFire) //fireRate value adjusts shots per second
            {
                nextFire = Time.time + fireRate;
                Instantiate(shot, shotSpawn.position, Quaternion.identity);  //instantiates a Shot in front of the player on button press
            }
        }
    }
}

