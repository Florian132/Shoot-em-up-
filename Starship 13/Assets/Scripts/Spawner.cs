using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public Renderer rend;
    public float timeBetweenEnemies = 0.25f;
    public float timeBetweenWaves = 5.0f;
    int Pattern_Number;
    public int enemiesPerWave = 10;
    private int currentNumberOfEnemies = 0;
    private bool IsSpawning = true;

    



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
       
    }

    void Update()
    {

    }

    //IEnumerator NextWave()
    //{
    //    float timer = 0;
    //    do
    //    {
    //        timer = Time.deltaTime;
    //        yield return null;
    //    }
    //    while (timer < timeBetweenWaves);
    //    SpawnEnemies();

        
    //}

    IEnumerator SpawnEnemies()
    {
        while (IsSpawning == true) 
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

            IsSpawning = false;
            yield return new WaitForSeconds(timeBetweenWaves);
            IsSpawning = true;
        }
        
    }

}
