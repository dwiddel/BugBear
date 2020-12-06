using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Player
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager instance;
        public AudioSource[] audioSources;
        public Slider volumeSlider;
        [HideInInspector] public float masterVolume = 1f;
        private string currentScene;
        public float initialVolume = 0.5f;
        private string initialInstall;

        private void Awake()
        {
            instance = this;
        }

        void Start()
        {
            currentScene = SceneManager.GetActiveScene().name;

            if (volumeSlider == null)
            {
                volumeSlider = GameObject.Find("Slider").GetComponent<Slider>();
            }
            
            volumeSlider.onValueChanged.AddListener(delegate {
                UpdateMasterVolume();
            });
            
            masterVolume = PlayerPrefs.GetFloat("MasterVolume");
            initialInstall = PlayerPrefs.GetString("InitialInstall", "true");

            if (initialInstall == "true")
            {
                PlayerPrefs.SetString("InitialInstall", "false");
                masterVolume = initialVolume;
                PlayerPrefs.SetFloat("MasterVolume", initialVolume);
            }
            volumeSlider.value = masterVolume;
            PlaySceneMusic();
        }

        private void UpdateMasterVolume()
        {
            masterVolume = volumeSlider.value;
            for (int i = 0; i < audioSources.Length; i++)
            {
                audioSources[i].volume = masterVolume;
            }
            PlayerPrefs.SetFloat("MasterVolume", masterVolume);
        } 

        private void PlaySceneMusic()
        {
            switch (currentScene)
            {
                case "Home":
                    audioSources[0].Play();
                    break;
                case "Level 1":
                    audioSources[8].Play();
                    break;
                case "Level 2":
                    audioSources[9].Play();
                    break;
                case "Level 3":
                    audioSources[10].Play();
                    break;
                case "Level 4 Endless":
                    audioSources[8].Play();
                    break;
                default:
                    break;
            }
        }
    }
}
