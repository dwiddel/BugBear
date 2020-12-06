using System.Collections;
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
        public GameObject shield;
        public Transform shotSpawn;
        public float fireRate;
        public VirtualJoystick moveJoystick;
        private float nextFire;
        AudioSource audioData;
        public GameObject[] enemy;
        public GameObject[] enemyFollow;
        public bool splitShot;
        public float splitShotOnTimer = 5;
        public float shieldOnTimer = 6;
        

        private void Awake()
        {
            instance = this;
            splitShot = false;
        }

        private void Update()
        {
            moveJoystick = GameObject.Find("VirtualJoystickContainer").GetComponent<VirtualJoystick>();
            if (Input.GetKeyDown("space"))
            {
                StartCoroutine(ShieldTimer());
            }
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
                SoundManager.instance.audioSources[1].Play();

                if (splitShot == true)
                {
                    Instantiate(shot, shotSpawn.position, Quaternion.Euler(new Vector3(0, 40, 0)));
                    Instantiate(shot, shotSpawn.position, Quaternion.Euler(new Vector3(0, -40, 0)));
                }
            }
        }

        public void OnTriggerEnter(Collider other)
        {

            if (other.gameObject.CompareTag("Nuke"))
            {
                other.gameObject.SetActive(false);
                GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");

                for (var i = 0; i < enemy.Length; i++)
                {
                    Destroy(enemy[i]);
                }
                other.gameObject.SetActive(false);
                GameObject[] enemyFollow = GameObject.FindGameObjectsWithTag("EnemyFollow");

                for (var i = 0; i < enemy.Length; i++)
                {
                    Destroy(enemyFollow[i]);
                }
            }
            if (other.gameObject.CompareTag("Split"))
            {
                other.gameObject.SetActive(false);
                StartCoroutine(SplitShotTimer());
            }
            if (other.gameObject.CompareTag("Shield"))
            {
                other.gameObject.SetActive(false);
                StartCoroutine(ShieldTimer());
            }
        }

        IEnumerator SplitShotTimer()
        {
            splitShot = true;
            yield return new WaitForSeconds(splitShotOnTimer);
            splitShot = false;
        }

        IEnumerator ShieldTimer()
        {
            shield.SetActive(true);
            yield return new WaitForSeconds(shieldOnTimer);
            shield.SetActive(false);
        }
    }
}

