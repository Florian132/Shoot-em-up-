using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject EasyEnemy;
    public GameObject MediumEnemy;
    //public GameObject HardEnemy;
    public GameObject Boss;

    public Renderer rend;

    private int[] pattern = {1, 1, 1, 1, 1, 1};
    private string patternText = "Pattern: ";

    public float timeBetweenEnemies = 0.25f;
    public float timeBetweenWaves = 5.0f;

    public int enemiesPerWave = 0;
    private int currentNumberOfEnemies = 0;
    private bool IsSpawning = true;
    private float Timer = 0.0f;
    private int WaveNumber = 0;
    public int Wave_Counter = 0;
    public int Waves_Until_Boss = 2;
    private int WavesAmount = 1;

    public GameObject[] enemies = new GameObject[2];


   



    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < pattern.Length; i++)
        {
            patternText = patternText + pattern[i];
        }
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
            float posX = Random.Range(Min_X + 0.5f, Max_X - 0.5f);
            float posY = transform.position.y;
            var spawnPoint = new Vector2(posX, posY);

            Instantiate(enemies[pattern[i]-1], spawnPoint, Quaternion.identity);
            currentNumberOfEnemies++;
            yield return new WaitForSeconds(timeBetweenEnemies);
        }
        yield return new WaitForSeconds(timeBetweenWaves);
        currentNumberOfEnemies = 0;
        IsSpawning = true;
    }

    IEnumerator SpawnEnemies_Level_Two()
    {


        enemiesPerWave = 12;
        float posY = transform.position.y;
        var Min_X = transform.position.x - rend.bounds.size.x / 2 + 1;
        var Max_X = transform.position.x + rend.bounds.size.x / 2 - 1;
        for (int i = 0; i < enemiesPerWave; i++)
        {
            if (currentNumberOfEnemies < 6)
            {
                float posX = Min_X;

                var spawnPoint = new Vector2(posX, posY);
                Instantiate(enemies[pattern[i]-1], spawnPoint, Quaternion.identity);
                currentNumberOfEnemies++;
                Min_X = Min_X + 1;
                yield return new WaitForSeconds(timeBetweenEnemies);
            }

            if (currentNumberOfEnemies >= 6 && currentNumberOfEnemies <= 12)
            {

                float posX = Max_X;

                var spawnPoint = new Vector2(posX, posY);
                Instantiate(enemies[pattern[i/2]-1], spawnPoint, Quaternion.identity);
                currentNumberOfEnemies++;
                Max_X = Max_X - 1;
                yield return new WaitForSeconds(timeBetweenEnemies);
            }
        }
        yield return new WaitForSeconds(timeBetweenWaves);
        currentNumberOfEnemies = 0;
        IsSpawning = true;



    }

    IEnumerator SpawnEnemies_Level_Three()
    {


        enemiesPerWave = 12;
        float posY = transform.position.y;
        var Min_X = transform.position.x - rend.bounds.size.x / 2 + 1;
        var Max_X = transform.position.x + rend.bounds.size.x / 2 - 1;
        for (int i = 0; i < enemiesPerWave; i++)
        {
            if (currentNumberOfEnemies < 6)
            {
                float posX = Max_X;

                var spawnPoint = new Vector2(posX, posY);
                Instantiate(enemies[pattern[i]-1], spawnPoint, Quaternion.identity);
                currentNumberOfEnemies++;
                Max_X = Max_X - 1;
                yield return new WaitForSeconds(timeBetweenEnemies);
            }

            if (currentNumberOfEnemies >= 6 && currentNumberOfEnemies <= 12)
            {

                float posX = Min_X;

                var spawnPoint = new Vector2(posX, posY);
                Instantiate(enemies[pattern[i/2]-1], spawnPoint, Quaternion.identity);
                currentNumberOfEnemies++;
                Min_X = Min_X + 1;
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
        int patternIndex = 0;
        for (int i = 0; i < 1; i++)
        {
            var spawnPoint1 = new Vector2(Min_X + 1, posY);
            var spawnPoint2 = new Vector2(Min_X + 3, posY);
            var spawnPoint3 = new Vector2(Min_X + 5, posY);
            var spawnPoint4 = new Vector2(Min_X + 7, posY);
            var spawnPoint5 = new Vector2(Min_X + 9, posY);
            Instantiate(enemies[pattern[patternIndex]-1], spawnPoint1, Quaternion.identity);
            patternIndex++;
            Instantiate(enemies[pattern[patternIndex] -1], spawnPoint2, Quaternion.identity);
            patternIndex++;
            Instantiate(enemies[pattern[patternIndex] -1], spawnPoint3, Quaternion.identity);
            patternIndex++;
            Instantiate(enemies[pattern[patternIndex] -1], spawnPoint4, Quaternion.identity);
            patternIndex++;
            Instantiate(enemies[pattern[patternIndex] -1], spawnPoint5, Quaternion.identity);
            patternIndex = 0;
            currentNumberOfEnemies = currentNumberOfEnemies + 5;

        }
        yield return new WaitForSeconds(timeBetweenWaves);
        currentNumberOfEnemies = 0;
        IsSpawning = true;
    }

    IEnumerator SpawnEnemies_Level_Boss()
    {

        currentNumberOfEnemies = 1;
        float posY = transform.position.y;
        float posX = transform.position.x;

        var spawnPoint = new Vector2(posX, posY);
        Instantiate(Boss, spawnPoint, Quaternion.identity);
        yield return new WaitForSeconds(15);

        currentNumberOfEnemies = 0;
        IsSpawning = true;
    }

    void Get_Random_Wave()
    {
        if(WavesAmount >= 10)
        {
            for (int i = 0; i < pattern.Length; i++)
            {
                pattern[i] = Random.Range(1, 3);

                patternText = patternText + " " + pattern[i];
            }
            Debug.Log(patternText);

            patternText = "Pattern:";
        }

        Debug.Log(patternText);
        

        Debug.Log("Wave amount: " + WavesAmount);
        
        WaveNumber = Random.Range(1, 5);
        

        Debug.Log(WaveNumber);

        if (WaveNumber == 1 && Waves_Until_Boss != 0)
        {
            Wave_Counter++;
            WavesAmount++;
            Waves_Until_Boss--;
            StartCoroutine(SpawnEnemies_Level_One());

        }

        else if (WaveNumber == 2 && Waves_Until_Boss != 0)
        {
            Wave_Counter++;
            WavesAmount++;
            Waves_Until_Boss--;
            StartCoroutine(SpawnEnemies_Level_Two());

        }

        else if (WaveNumber == 3 && Waves_Until_Boss != 0)
        {
            Wave_Counter++;
            WavesAmount++;
            Waves_Until_Boss--;
            StartCoroutine(SpawnEnemies_Level_Three());

        }

        else if (WaveNumber == 4 && Waves_Until_Boss != 0)
        {
            Wave_Counter++;
            WavesAmount++;
            Waves_Until_Boss--;
            StartCoroutine(SpawnEnemies_Level_Four());

        }

        else if (Waves_Until_Boss == 0) 
        {
            StartCoroutine(SpawnEnemies_Level_Boss());
            Waves_Until_Boss = 2;
           
        }
    }

    public void Wave_Zero()
    {
        Wave_Counter = 0;
    }

}
