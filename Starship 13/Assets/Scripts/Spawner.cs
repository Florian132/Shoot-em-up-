using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public float timeBeforeSpawning = 1.5f;
    public Renderer rend;
    public float timeBetweenEnemies = 0.25f;
    public float timeBeforeWaves = 2.0f;
    int Pattern_Number;
    public int enemiesPerWave = 10;
    private int currentNumberOfEnemies = 0;

    



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {


    }

    IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(timeBeforeSpawning);
        while(true)
        {
            if (currentNumberOfEnemies <=0)
            {
                for (int i = 0; i < enemiesPerWave; i++)
                {
                    var Min_X = transform.position.x - rend.bounds.size.x / 2;
                    var Max_X = transform.position.x + rend.bounds.size.x / 2;
                    float posX = Random.Range(Min_X, Max_X);
                    float posY = transform.position.y;
                    var spawnPoint = new Vector2(posX, posY);
                    Instantiate(EnemyPrefab, spawnPoint, Quaternion.identity);
                    currentNumberOfEnemies++;
                    yield return new WaitForSeconds(timeBetweenEnemies);
                }
            }
            yield return new WaitForSeconds(timeBeforeWaves);
        }
    }



    //void SpawnEnemies()
    //{

    //    var Min_X = transform.position.x - rend.bounds.size.x / 2;

    //    var Max_X = transform.position.x + rend.bounds.size.x / 2;

    //    var spawnPoint = new Vector2(Random.Range(Min_X, Max_X), transform.position.y);

    //    Instantiate(EnemyPrefab, spawnPoint, Quaternion.identity);
    //}
}
