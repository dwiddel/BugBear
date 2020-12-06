using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

namespace Player
{
    public class GameController : MonoBehaviour
    {
        public static GameController instance;
        public GameObject enemy;
        public GameObject food;
        public GameObject nuke;
        public GameObject shield;
        public GameObject split;
        public GameObject enemyTwo;
        public Vector3 enemySpawnValues;
        public Vector3 foodSpawnValues;
        public Vector3 nukeSpawnValues;
        public Vector3 shieldSpawnValues;
        public Vector3 splitSpawnValues;
        public Vector3 enemyTwoSpawnValues;
        public int enemyCount;
        public int foodCount;
        public int nukeCount;
        public int shieldCount;
        public int splitCount;
        public int enemyTwoCount;
        public float enemySpawnWait;
        public float enemyStartWait;
        public float enemyWaveWait;
        public float foodSpawnWait;
        public float foodStartWait;
        public float foodWaveWait;
        public float nukeSpawnWait;
        public float nukeStartWait;
        public float nukeWaveWait;
        public float shieldSpawnWait;
        public float shieldStartWait;
        public float shieldWaveWait;
        public float splitSpawnWait;
        public float splitStartWait;
        public float splitWaveWait;
        public float enemyTwoSpawnWait;
        public float enemyTwoStartWait;
        public float enemyTwoWaveWait;
        private string currentScene;
        public bool isScoreTextAvailable = true;
        public Text scoreText;
        public int score;
        public int highScore;
        public int neededPointsLvl1 = 200;
        public int neededPointsLvl2 = 400;
        public int neededPointsLvl3 = 600;
        private int lvlScore;
        //private bool isLvl4ScoreSet;

        private void Awake()
        {
            instance = this;
        }

        void Start()
        {
            score = PlayerPrefs.GetInt("Score");
            highScore = PlayerPrefs.GetInt("HighScore");
            currentScene = SceneManager.GetActiveScene().name;
            UpdateScore();
            SetNextScene();
            StartCoroutine(SpawnEnemyWaves());
            StartCoroutine(SpawnFoodWaves());
            StartCoroutine(SpawnnukeWaves());
            StartCoroutine(SpawnShieldWaves());
            StartCoroutine(SpawnsplitWaves());
            StartCoroutine(SpawnEnemyTwoWaves());
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                ClearScore();
                ClearHighScore();
            }
        }

        IEnumerator SpawnEnemyWaves()
        {
            yield return new WaitForSeconds(enemyStartWait);
            while (true)
            {
                for (int i = 0, j = 0; i < enemyCount; i++)
                {
                    Vector3 spawnPosition = new Vector3(Random.Range(-enemySpawnValues.x, enemySpawnValues.x), enemySpawnValues.y, enemySpawnValues.z); //For 'x' the script will chose random numbers between x and -x
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(enemy, spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(enemySpawnWait);
                }
                //Spawn Enemy
                yield return new WaitForSeconds(enemyWaveWait);
                //Wait
            }

        }
        IEnumerator SpawnFoodWaves()
        {
            yield return new WaitForSeconds(foodStartWait);
            while (true)
            {
                for (int i = 0, j = 0; i < foodCount; i++)
                {
                    Vector3 foodspawnPosition = new Vector3(Random.Range(-foodSpawnValues.x, foodSpawnValues.x), foodSpawnValues.y, foodSpawnValues.z);
                    Quaternion foodspawnRotation = Quaternion.identity;
                    Instantiate(food, foodspawnPosition, foodspawnRotation);
                    Debug.Log("Food Instantiated!");
                    yield return new WaitForSeconds(foodSpawnWait);
                }
                //Spawn Food
                yield return new WaitForSeconds(foodWaveWait);
                //Wait
            }

        }
        IEnumerator SpawnShieldWaves()
        {
            yield return new WaitForSeconds(shieldStartWait);
            while (true)
            {
                for (int i = 0, j = 0; i < shieldCount; i++)
                {
                    Vector3 shieldspawnPosition = new Vector3(Random.Range(-shieldSpawnValues.x, shieldSpawnValues.x), shieldSpawnValues.y, shieldSpawnValues.z);
                    Quaternion shieldspawnRotation = Quaternion.identity;
                    Instantiate(shield, shieldspawnPosition, shieldspawnRotation);
                    Debug.Log("Shield Instantiated!");
                    yield return new WaitForSeconds(shieldSpawnWait);
                }
                //Spawn Shield Pickup
                yield return new WaitForSeconds(shieldWaveWait);
                //Wait
            }

        }
        IEnumerator SpawnnukeWaves()
        {
            yield return new WaitForSeconds(nukeStartWait);
            while (true)
            {
                for (int i = 0, j = 0; i < nukeCount; i++)
                {
                    Vector3 nukespawnPosition = new Vector3(Random.Range(-nukeSpawnValues.x, nukeSpawnValues.x), nukeSpawnValues.y, nukeSpawnValues.z);
                    Quaternion nukespawnRotation = Quaternion.identity;
                    Instantiate(nuke, nukespawnPosition, nukespawnRotation);
                    Debug.Log("Nuke Instantiated!");
                    yield return new WaitForSeconds(nukeSpawnWait);
                }
                //Spawn Nuke Pickup
                yield return new WaitForSeconds(nukeWaveWait);
                //Wait
            }

        }
        IEnumerator SpawnsplitWaves()
        {
            yield return new WaitForSeconds(splitStartWait);
            while (true)
            {
                for (int i = 0, j = 0; i < splitCount; i++)
                {
                    Vector3 splitspawnPosition = new Vector3(Random.Range(-splitSpawnValues.x, splitSpawnValues.x), splitSpawnValues.y, splitSpawnValues.z);
                    Quaternion splitspawnRotation = Quaternion.identity;
                    Instantiate(split, splitspawnPosition, splitspawnRotation);
                    Debug.Log("Split Instantiated!");
                    yield return new WaitForSeconds(splitSpawnWait);
                }
                //Spawn Split Pickup
                yield return new WaitForSeconds(splitWaveWait);
                //Wait
            }

        }
        IEnumerator SpawnEnemyTwoWaves()
        {
            yield return new WaitForSeconds(enemyTwoStartWait);
            while (true)
            {
                for (int i = 0, j = 0; i < enemyCount; i++)
                {
                    Vector3 spawnPosition = new Vector3(Random.Range(-enemyTwoSpawnValues.x, enemyTwoSpawnValues.x), enemyTwoSpawnValues.y, enemyTwoSpawnValues.z); //For 'x' the script will chose random numbers between x and -x
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(enemyTwo, spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(enemyTwoSpawnWait);
                }
                //Spawn Enemy Two
                yield return new WaitForSeconds(enemyTwoWaveWait);
                //Wait
            }

        }

        public void AddScore(int newScoreValue)
        {
            score += newScoreValue;
            UpdateScore();
            NextLevelCheck();
            SetHighScore();
        }

        private void UpdateScore()
        {
            scoreText.text = "Score: " + score;
        }

        public void SetRespawnScore()
        {
            switch (currentScene)
            {
                case "Level 1":
                    lvlScore = PlayerPrefs.GetInt("Lvl1StartScore");
                    break;
                case "Level 2":
                    lvlScore = PlayerPrefs.GetInt("Lvl2StartScore");
                    break;
                case "Level 3":
                    lvlScore = PlayerPrefs.GetInt("Lvl3StartScore");
                    break;
                case "Level 4 Endless":
                    lvlScore = PlayerPrefs.GetInt("Lvl4StartScore");
                    Debug.Log("Level 4 Score: " + lvlScore);
                    break;
                default:
                    break;
            }
            score = lvlScore;
            UpdateScore();
        }

        private void NextLevelCheck()
        {
            if (score >= neededPointsLvl1 && currentScene == "Level 1")
            {
                PlayerPrefs.SetInt("Score", score);
                PlayerPrefs.SetInt("Lvl1StartScore", score);
                CanvasManager.instance.LoadSceneByName("LvlTransition");
            }
            else if (score >= neededPointsLvl2 && currentScene == "Level 2")
            {
                PlayerPrefs.SetInt("Score", score);
                PlayerPrefs.SetInt("Lvl2StartScore", score);
                CanvasManager.instance.LoadSceneByName("LvlTransition");
            }
            else if (score >= neededPointsLvl3 && currentScene == "Level 3")
            {
                PlayerPrefs.SetInt("Score", score);
                PlayerPrefs.SetInt("Lvl3StartScore", score);
                CanvasManager.instance.LoadSceneByName("LvlTransition");
            }
            else if (currentScene == "Level 4 Endless")
            {
                PlayerPrefs.SetInt("Score", score);
                PlayerPrefs.SetInt("Lvl4StartScore", score);

            }
        }

        public void ClearScore()
        {
            PlayerPrefs.SetInt("Score", 0);
            score = 0;
            if (isScoreTextAvailable)
            {
                scoreText.text = "Score: " + score;
            }
        }

        public void ClearHighScore()
        {
            PlayerPrefs.SetInt("HighScore", 0);
        }

        public void ScoreTextAvailable() // Prevents Error when going to LvlTransition scene to Home screen
        {
            isScoreTextAvailable = false;
        }

        public void SetNextScene()
        {
            switch (currentScene)
            {
                case "Level 1":
                    PlayerPrefs.SetString("NextScene", "Level 2");
                    break;
                case "Level 2":
                    PlayerPrefs.SetString("NextScene", "Level 3");
                    break;
                case "Level 3":
                    PlayerPrefs.SetString("NextScene", "Level 4 Endless");
                    break;
                case "Level 4 Endless":
                    PlayerPrefs.SetString("NextScene", "Home");
                    break;
                default:
                    break;
            }
        }

        public void SetHighScore()
        {
            if (score >= highScore)
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
        }
    }
}


