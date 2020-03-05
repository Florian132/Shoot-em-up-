﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject EasyEnemy;
    public GameObject MediumEnemy;
    public GameObject HardEnemy;
    public GameObject Boss;

    public Renderer rend;


    public float timeBetweenEnemies = 0.25f;
    public float timeBetweenWaves = 5.0f;

    public int enemiesPerWave = 0;
    private int currentNumberOfEnemies = 0;
    private bool IsSpawning = true;
    private float Timer = 0.0f;
    private int WaveNumber = 0;
    public int Wave_Counter = 0;






    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        Timer += Time.deltaTime;
        //InvokeRepeating("Random_Wave", timeBetweenEnemies, timeBetweenWaves);
        while (IsSpawning == true && currentNumberOfEnemies == 0)
        {
            Get_Random_Wave();
            IsSpawning = false;
        }


    }

    IEnumerator SpawnEnemies_Level_One()
    {


        enemiesPerWave = 5;
        for (int i = 0; i < enemiesPerWave; i++)
        {
            var Min_X = transform.position.x - rend.bounds.size.x / 2;
            var Max_X = transform.position.x + rend.bounds.size.x / 2;
            float posX = Random.Range(Min_X, Max_X);
            float posY = transform.position.y;
            var spawnPoint = new Vector2(posX, posY);
            Instantiate(EasyEnemy, spawnPoint, Quaternion.identity);
            currentNumberOfEnemies++;
            yield return new WaitForSeconds(timeBetweenEnemies);
        }
        yield return new WaitForSeconds(timeBetweenWaves);
        currentNumberOfEnemies = 0;
        IsSpawning = true;



    }

    IEnumerator SpawnEnemies_Level_Two()
    {


        enemiesPerWave = 16;
        float posY = transform.position.y;
        var Min_X = transform.position.x - rend.bounds.size.x / 2 + 2;
        var Max_X = transform.position.x + rend.bounds.size.x / 2 - 2;
        for (int i = 0; i < enemiesPerWave; i++)
        {
            if (currentNumberOfEnemies < 8)
            {
                float posX = Min_X;

                var spawnPoint = new Vector2(posX, posY);
                Instantiate(EasyEnemy, spawnPoint, Quaternion.identity);
                currentNumberOfEnemies++;
                Min_X = Min_X + 2;
                yield return new WaitForSeconds(timeBetweenEnemies);
            }

            if (currentNumberOfEnemies >= 8 && currentNumberOfEnemies < 16)
            {

                float posX = Max_X;

                var spawnPoint = new Vector2(posX, posY);
                Instantiate(EasyEnemy, spawnPoint, Quaternion.identity);
                currentNumberOfEnemies++;
                Max_X = Max_X - 2;
                yield return new WaitForSeconds(timeBetweenEnemies);
            }
        }
        yield return new WaitForSeconds(timeBetweenWaves);
        currentNumberOfEnemies = 0;
        IsSpawning = true;



    }

    IEnumerator SpawnEnemies_Level_Three()
    {


        enemiesPerWave = 16;
        float posY = transform.position.y;
        var Min_X = transform.position.x - rend.bounds.size.x / 2 + 2;
        var Max_X = transform.position.x + rend.bounds.size.x / 2 - 2;
        for (int i = 0; i < enemiesPerWave; i++)
        {
            if (currentNumberOfEnemies < 8)
            {
                float posX = Max_X;

                var spawnPoint = new Vector2(posX, posY);
                Instantiate(EasyEnemy, spawnPoint, Quaternion.identity);
                currentNumberOfEnemies++;
                Max_X = Max_X - 2;
                yield return new WaitForSeconds(timeBetweenEnemies);
            }

            if (currentNumberOfEnemies >= 8 && currentNumberOfEnemies < 16)
            {

                float posX = Min_X;

                var spawnPoint = new Vector2(posX, posY);
                Instantiate(EasyEnemy, spawnPoint, Quaternion.identity);
                currentNumberOfEnemies++;
                Min_X = Min_X + 2;
                yield return new WaitForSeconds(timeBetweenEnemies);
            }

        }
        yield return new WaitForSeconds(timeBetweenWaves);
        currentNumberOfEnemies = 0;
        IsSpawning = true;





    }


    IEnumerator SpawnEnemies_Level_Four()
    {
        float posY = transform.position.y;
        var Min_X = transform.position.x - rend.bounds.size.x / 2;
        var Max_X = transform.position.x + rend.bounds.size.x / 2;
        for (int i = 0; i < 1; i++)
        {
            var spawnPoint1 = new Vector2(Min_X + 2, posY);
            var spawnPoint2 = new Vector2(Min_X + 4, posY);
            var spawnPoint3 = new Vector2(Min_X + 6, posY);
            var spawnPoint4 = new Vector2(Min_X + 8, posY);
            var spawnPoint5 = new Vector2(Min_X + 10, posY);
            var spawnPoint6 = new Vector2(Min_X + 12, posY);
            var spawnPoint7 = new Vector2(Min_X + 14, posY);
            var spawnPoint8 = new Vector2(Min_X + 16, posY);
            Instantiate(EasyEnemy, spawnPoint1, Quaternion.identity);
            Instantiate(EasyEnemy, spawnPoint2, Quaternion.identity);
            Instantiate(EasyEnemy, spawnPoint3, Quaternion.identity);
            Instantiate(EasyEnemy, spawnPoint4, Quaternion.identity);
            Instantiate(EasyEnemy, spawnPoint5, Quaternion.identity);
            Instantiate(EasyEnemy, spawnPoint6, Quaternion.identity);
            Instantiate(EasyEnemy, spawnPoint7, Quaternion.identity);
            Instantiate(EasyEnemy, spawnPoint8, Quaternion.identity);
            currentNumberOfEnemies = currentNumberOfEnemies + 8;

        }
        yield return new WaitForSeconds(timeBetweenWaves);
        currentNumberOfEnemies = 0;
        IsSpawning = true;
    }

    void Get_Random_Wave()
    {
        WaveNumber = Random.Range(1, 5);

        Debug.Log(WaveNumber);

        if (WaveNumber == 1)
        {
            Wave_Counter++;
            StartCoroutine(SpawnEnemies_Level_One());

        }

        if (WaveNumber == 2)
        {
            Wave_Counter++;
            StartCoroutine(SpawnEnemies_Level_Two());

        }

        if (WaveNumber == 3)
        {
            Wave_Counter++;
            StartCoroutine(SpawnEnemies_Level_Three());

        }

        if (WaveNumber == 4)
        {
            Wave_Counter++;
            StartCoroutine(SpawnEnemies_Level_Four());

        }
    }

    public void Wave_Zero()
    {
        if (Wave_Counter == 1)
        {
            Wave_Counter = 0;
        }
    }

}
