using System.Collections.Generic;
using UnityEngine;

namespace SpawnSystem
{
    public class EnemySpawnManager : MonoBehaviour
    {
        public List<Enemy> enemies = new List<Enemy>();
        private int currWave = 1;
        private int waveValue;
        public List<GameObject> enemiesToSpawn = new List<GameObject>();

        public Transform[] spawnLocation;
        private int spawnIndex;

        public int waveDuration;
        private float waveTimer;
        private float spawnInterval;
        private float spawnTimer;
        private GameObject player;

        // Start is called before the first frame update
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            GenerateWave();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (spawnTimer <= 0)
            {
                if (enemiesToSpawn.Count > 0)
                {
                    var indexToSpawn = spawnIndex;
                    var dotProduct = Vector3.Dot(player.transform.forward, spawnLocation[indexToSpawn].position - player.transform.position);
                    if (dotProduct < 0)
                    {
                        GameObject enemy = (GameObject)Instantiate(enemiesToSpawn[0], spawnLocation[spawnIndex].position, 
                            Quaternion.identity);
                        enemiesToSpawn.RemoveAt(0);
                        spawnTimer = spawnInterval;
                    }

                    if (spawnIndex + 1 <= spawnLocation.Length - 1)
                    {
                        spawnIndex++;
                    }
                    else
                    {
                        spawnIndex = 0;
                    }
                }
                else
                {
                    waveTimer = 0; // if no enemies remain, end wave
                }
            }
            else
            {
                spawnTimer -= Time.fixedDeltaTime;
                waveTimer -= Time.fixedDeltaTime;
            }

            if (waveTimer <= 0)
            {
                currWave++;
                GenerateWave();
            }
        }

        public void GenerateWave()
        {
            waveValue = Mathf.RoundToInt((currWave/2) + 2);
            GenerateEnemies();

            spawnInterval = waveDuration / enemiesToSpawn.Count; 
            waveTimer = waveDuration; 
        }

        public void GenerateEnemies()
        {

            List<GameObject> generatedEnemies = new List<GameObject>();
            while (waveValue > 0 || generatedEnemies.Count < 50)
            {
                int randEnemyId = Random.Range(0, enemies.Count);
                int randEnemyCost = enemies[randEnemyId].cost;
                
                if (waveValue - randEnemyCost >= 0)
                {
                    generatedEnemies.Add(enemies[randEnemyId].enemyPrefab);
                    waveValue -= randEnemyCost;
                }
                else if (waveValue <= 0)
                {
                    break;
                }
            }

            enemiesToSpawn.Clear();
            enemiesToSpawn = generatedEnemies;
        }
    }
    
    [System.Serializable]
    public class Enemy
    {
        public GameObject enemyPrefab;
        public int cost;
    }
}

