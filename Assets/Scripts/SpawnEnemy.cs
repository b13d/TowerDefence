using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    public List<GameObject> enemyList;
    

    void Start()
    {
        enemyPrefab.GetComponent<EnemyController>().speed = 1;
        enemyList.Add(Instantiate(enemyPrefab, new Vector3(-10, 1.5f, 0), enemyPrefab.transform.rotation, transform));
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyList.Count == 0)
        {
            GameManager.wave++;

            if (GameManager.wave % 5 == 0)
            {
                enemyPrefab.GetComponent<EnemyController>().speed += 1;
            }

            enemyList.Clear();

            for(int i = 0; i < GameManager.wave; i++)
            {
                enemyList.Add(Instantiate(enemyPrefab, new Vector3(-10 - i, 1.5f, 0), enemyPrefab.transform.rotation, transform));
            }

        }
    }
}
