using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawn : MonoBehaviour
{

    [System.Serializable]
    public class Wave
    {
        public enemy[] enemies;
        public int count;
        public float timeBtwSpawn;
    }
    public Wave[] wave;
    public Transform[] spawnpoint;
    public float timeBtwWave;

    private Wave currentWave;
    private int currentWaveIndex;
    private Transform player;

    private bool check;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(StartNextWave(currentWaveIndex));
    }

    IEnumerator StartNextWave(int index)
    {
        yield return new WaitForSeconds(timeBtwWave);
        StartCoroutine(SpawnWave(index));
    }
    IEnumerator SpawnWave(int index)
    {
        currentWave = wave[index];
        for(int i = 0; i < currentWave.count; i++)
        {
            if(player == null)
            {
                yield break;
            }
            enemy randomEnemy = currentWave.enemies[Random.Range(0, currentWave.enemies.Length)];
            Transform randomSpot = spawnpoint[Random.Range(0, spawnpoint.Length)];
            Instantiate(randomEnemy, randomSpot.position, randomSpot.rotation);

            if(i==currentWave.count - 1)
            {
                check = true;
            }
            else
            {
                check = false;
            }
            yield return new WaitForSeconds(currentWave.timeBtwSpawn);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(check == true && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            check = false;
            if (currentWaveIndex + 1 < wave.Length)
            {
                currentWaveIndex++;
                StartCoroutine(StartNextWave(currentWaveIndex));
            }
            else
            {
                Debug.Log("Game finished");
            }
        }
    }
    
}
