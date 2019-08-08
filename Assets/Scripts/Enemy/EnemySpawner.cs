using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private int enemyCount;
    Vector3 randomposition;
    [SerializeField] private GameObject _enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        enemyCount = Random.Range(5, 10);
        SpawnEnemy();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length <2)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            randomposition = new Vector3(Random.Range(-8.5f, 7), 1, Random.Range(15, 98));
            Instantiate(_enemyPrefab, randomposition, Quaternion.identity);
        }
    }
}
