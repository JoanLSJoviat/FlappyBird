using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using Random = UnityEngine.Random;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnInterval = 2f; 
    public float speed = 2f; 
    public float minY, maxY; 
    public float xPos; 
    public float destroyPoint;
    public GameObject obstaclesParent;
    public GameManager gm;
    void Start()
    {
    }

    public IEnumerator SpawnPipes()
    {
        while (gm.startGame)
        {
           
            float spawnY = Random.Range(minY, maxY);

           
            GameObject pipe = Instantiate(pipePrefab, new Vector3(xPos, spawnY, 0), Quaternion.identity, obstaclesParent.transform);

           
            StartCoroutine(MovePipe(pipe));

          
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public IEnumerator MovePipe(GameObject pipe)
    {
            while (pipe != null && pipe.transform.position.x > destroyPoint)
            {
               
                pipe.transform.position = new Vector3(pipe.transform.position.x - speed * Time.deltaTime, pipe.transform.position.y, pipe.transform.position.z);

                yield return null;
            }

        
            Destroy(pipe);
    }

    public void StartSpawnCoroutine()
    {
        StartCoroutine(SpawnPipes());
    }

    private void Update()
    {
        if (gm.gameOverMsg.activeSelf == true)
        {
            StopCoroutine(MovePipe(null));
        }
    }
}