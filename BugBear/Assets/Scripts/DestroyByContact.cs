using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Player
{
    public class DestroyByContact : MonoBehaviour
    {
        public Animator animator;
        //private Rigidbody2D rigid;
        public int scoreValue;
        private GameController gameController;

        void Start()
        {
            //rigid = GetComponent<Rigidbody2D>();
            GameObject gameControllerObject = GameObject.FindWithTag("GameController"); //This section is to detect if the object that collides with this script also has the 'GameController' script
            if (gameControllerObject != null)                                                 //And apply the values associated with that script.
            {
                //Debug.Log("CONTROLLER FOUND");
                gameController = gameControllerObject.GetComponent<GameController>();
            }
            if (gameControllerObject == null)
            {
                //Debug.Log("Cannot find 'GameController' script");
            }
        }
        void Awake()
        {

        }

        void Update()
        {

        }

        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                StartCoroutine(DeathAnimation());
                PlayerHealth.instance.TakeDamage(0.1f);
            }
            else if (other.tag == "Boundary")
            {
                return;
            }
            else if (other.tag == "Enemy")
            {
                return;
            }
            else if (other.tag == "Collectible")
            {
                return;
            }
            else if (other.tag == "Boundary")
            {
                return;
            }
            else if (other.tag == "BubbleShield")
            {
                StartCoroutine(DeathAnimation());
            }
            else if (other.tag == "Projectile")
            {
                StartCoroutine(DeathAnimation());

                gameController.AddScore(scoreValue); //add score when hitting this object


                Destroy(other.gameObject); //destroys projectile

                return;
            }
        }
        IEnumerator DeathAnimation()
        {
            SoundManager.instance.audioSources[2].Play();
            animator.SetBool("DeathState", true); // go into death animation
            this.GetComponent<BoxCollider>().enabled = false;
            yield return new WaitForSeconds(0.3f); // time of animation
            Destroy(gameObject);
        }
    }
}

