using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CloudFine.ThrowLab
{
    public class WaveSpawner : MonoBehaviour
    {
        public enum SpawnState { Spawning, Waiting, Counting };

        public int WaveCount = 1;

        public ChangeText changetext;

        public bool gameOver = false;

        public GameObject LabMan;

        [System.Serializable]
        public class Wave
        {
            public string name;
            public Transform enemy;
            public int count;
            public float rate;

            public Wave(string Name, Transform Enemy, int Count, float Rate)
            {
                name = Name;
                enemy = Enemy;
                count = Count;
                rate = Rate;
            }
        }

        public Wave[] waves;
        private int nextWave = 0;

        public Transform bus;

        public float timeBetweenWaves = 20f;
        public float waveCountdown;

        private float searchCountdown = 1f;

        public SpawnState state = SpawnState.Counting;

        public Transform Lane1;
        public Transform Lane2;
        public Transform Lane3;

        void Start()
        {
            waveCountdown = timeBetweenWaves;

        }

        void Update()
        {
            if (WaveCount > 1)
            {
                LabMan.GetComponent<LabManager>().introduce = 1;
                if (WaveCount > 3)
                {
                    LabMan.GetComponent<LabManager>().introduce = 2;
                }
            }
            if (Input.GetKey("escape"))
                Application.Quit();

            if (state == SpawnState.Waiting)
            {
                if (!EnemyIsAlive())
                {
                    WaveCompleted();
                }
                else
                {
                    return;
                }
            }

            if (waveCountdown <= 0)
            {
                if (state != SpawnState.Spawning)
                {
                    StartCoroutine(SpawnWave(waves[nextWave]));
                }
            }
            else
            {
                waveCountdown -= Time.deltaTime;
            }
        }

        void WaveCompleted()
        {
            WaveCount++;

            changetext.GetComponent<ChangeText>().changeRound(WaveCount);


            state = SpawnState.Counting;
            waveCountdown = timeBetweenWaves;


            nextWave++;
        }

        bool EnemyIsAlive()
        {
            searchCountdown -= Time.deltaTime;
            if (searchCountdown <= 0f)
            {
                searchCountdown = 1f;
                if (GameObject.FindGameObjectWithTag("Vehicle") == null)
                {
                    return false;
                }
            }
            return true;
        }

        public int count = 5;
        public float rate = 10;
        public int ROCcount = 3;



        IEnumerator SpawnWave(Wave _wave)
        {
            if (!gameOver)
            {
                state = SpawnState.Spawning;

                //make wave

                Wave currentWave = new Wave("wave", bus, count, rate);



                for (int i = 0; i < currentWave.count; i++)
                {
                    SpawnEnemy(currentWave.enemy);
                    yield return new WaitForSeconds(currentWave.rate);
                }

                //increase wave

                count = count + ROCcount;

                if (rate > 3.5f)
                {
                    rate = rate - .25f;
                }


                state = SpawnState.Waiting;

                yield break;
            }

        }

        void SpawnEnemy(Transform _enemy)
        {
            int _lane = Random.Range(1, 4);
            print(_lane);
            if (_lane >= 3)
            {
                Instantiate(_enemy, Lane1.position, Lane1.rotation);
            }
            else if (_lane >= 2)
            {
                Instantiate(_enemy, Lane2.position, Lane2.rotation);
            }
            else if (_lane >= 1)
            {
                Instantiate(_enemy, Lane3.position, Lane3.rotation);
            }
            print("Spawning enemy at" + _enemy.name);
        }


    }
}

