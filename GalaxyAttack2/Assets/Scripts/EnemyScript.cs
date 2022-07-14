using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{


    public GameObject Enemy; 

    float maxSpawnRateInSeconds = 5f; 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void spawnEnemy() 
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2 (0,0)); 

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));

        GameObject anEnemy = (GameObject)Instantiate (Enemy);
        anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

        ScheduleNextEnemySpawn();
    }

    void ScheduleNextEnemySpawn()
    {
            float spawnInNSeconds; 

            if(maxSpawnRateInSeconds > 1f)
            {
                spawnInNSeconds = Random.Range(1f, maxSpawnRateInSeconds);
            }
            else 

                spawnInNSeconds = 1f; 

                Invoke("spawnEnemy", spawnInNSeconds);
    }

    void IncreaseSpawnRate()
    {
        if(maxSpawnRateInSeconds > 1f)
            maxSpawnRateInSeconds--; 
        
        if(maxSpawnRateInSeconds == 1f)
            CancelInvoke("IncreaseSpawnRate");
    }

    public void turnOnEnemySpawner()
    {
        float maxSpawnRateInSeconds = 5f; 
        Invoke("spawnEnemy", maxSpawnRateInSeconds);
        InvokeRepeating("IncreaseSpawnRate", 0f, 30f);
    }

    public void undoEnemySpawner()
    {
        CancelInvoke("spawnEnemy");
        CancelInvoke("IncreaseSpawnRate");
    }
}
