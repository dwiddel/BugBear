using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        public static PlayerHealth instance;
        private float counterTimer;
        [HideInInspector] public float maxHealth = 1f;
        [HideInInspector] public float currentHealth;
        public float healthDepletionSpeed = 0.01f; //Amount that the health declines
        public float counterTimerMax = 0.1f;
        public Slider healthBar;
        private float previousHealthDivided;
        private float newHealthDivided;
        private float healthGainCheck;
        private float newHealthGainAmount;
        public bool takeDamage = true;

        private void Awake()
        {
            instance = this;
        }
        
        private void Start()
        {
            counterTimer = counterTimerMax;
            currentHealth = maxHealth;
            healthBar.value = maxHealth;
        }

        private void Update()
        {
            counterTimer -= Time.fixedDeltaTime;
            if (counterTimer <= 0)
            {
                TakeDamageOvertime(healthDepletionSpeed);
                counterTimer = counterTimerMax;
            }
        }

        public void TakeDamageToggle()
        {
            takeDamage = !takeDamage;
        }

        public void TakeDamageOvertime(float damage)
        {
            if (takeDamage)
            {
                previousHealthDivided = currentHealth / maxHealth;
                currentHealth -= damage;
                newHealthDivided = currentHealth / maxHealth;
                healthBar.value = currentHealth;

                if (healthBar.value <= 0)
                {
                    SoundManager.instance.audioSources[3].Play();
                    CanvasManager.instance.Death();
                }

                healthBar.value = Mathf.Lerp(previousHealthDivided, newHealthDivided, 0.1f);
            }
        }

        public void TakeDamage(float take)
        {
            if (healthBar.value > 0)
            {
                currentHealth -= take;
                healthBar.value = currentHealth;
            }
        }

        public void GainHealth(float gain)
        {
            // Checks to see if the amount depleted on the health bar is smaller than the gain amount and changes the amount accordingly
            healthGainCheck = maxHealth - currentHealth;

            if (healthBar.value < maxHealth)
            {
                if (healthGainCheck < gain)
                {
                    newHealthGainAmount = healthGainCheck;
                    currentHealth += newHealthGainAmount;
                }
                else
                {
                    currentHealth += gain;
                }
                healthBar.value = currentHealth;  
            }
        }
    }
}

