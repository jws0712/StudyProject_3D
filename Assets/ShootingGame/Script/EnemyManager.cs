 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int pollSize = 10;

    public List<GameObject> enemyObjectPool;

    public Transform[] spawnPoints;

    float minTime = 0.5f;

    float maxTime = 1.5f;


    float currentTime;

    public float createTime = 1;

    public GameObject enemyFactory;

    // Start is called before the first frame update
    void Start()
    {
        createTime = Random.Range(minTime, maxTime);

        enemyObjectPool = new List<GameObject>();

        for (int i = 0; i < pollSize; i++)
        {
            GameObject enemy = Instantiate(enemyFactory);

            enemyObjectPool.Add(enemy);

            enemy.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime > createTime)
        {
            if (enemyObjectPool.Count > 0)
            {
                GameObject enemy = enemyObjectPool[0];

                enemyObjectPool.Remove(enemy);

                
                int index = Random.Range(0, spawnPoints.Length);

                enemy.transform.position = spawnPoints[index].position;

                enemy.SetActive(true);

            }
            

                createTime = Random.Range(minTime, maxTime);
                currentTime = 0;
            

        }
    }
}
