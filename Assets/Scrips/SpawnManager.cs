using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private GameObject enemyContainer;

    private bool stopSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    //spawn game objects every 5 seconds
    //Create a coroutine of type IEnumorator -- Yield Events
    //while loop
    
    IEnumerator SpawnRoutine()
    {
        while (stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8.0f, 8f), 7, 0f);
            GameObject newEnemy = Instantiate(enemyPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = enemyContainer.transform;           
            yield return new WaitForSeconds(5.0f);

        }


        //while loop (infinate loop)
        //Instntiate enemy prefab
        //yeild for 5 seconds

        public void OnPlayerDeath()
        {
            stopSpawning = true;
        }

    }
}
