using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    private int enemyCount;
    Vector3 randomposition;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject[] _enemyPrefab_Toon;
    [SerializeField] private float _enemyHealth = 100f;
    [SerializeField] private float _enemyBoost = 5f;

    public EnemySpawner()
    {

    }



    // Start is called before the first frame update
    void Start()
    {
        enemyCount = UnityEngine.Random.Range(5, 10);
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

    /// <summary>
    /// Instantiating Enemy 
    /// </summary>
    private void SpawnEnemy()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            randomposition = new Vector3(Random.Range(-8.5f, 7), 1, Random.Range(15, 98));

            GameObject enemies = _enemyPrefab_Toon[Random.Range(0, 4)];

            Instantiate(enemies, randomposition, Quaternion.identity);


        }


        
    }

    /// <summary>
    /// Reducing Health for based on the object passed
    /// </summary>
    /// <param name="loggerInterface"></param>
    private void ReduceHealth(ILoggerInterface loggerInterface)
    {
        if (_enemyHealth == 100f)
        {
            print("Enemy is Healthy");
        }
        else
        {
            _enemyHealth -= _enemyBoost;
            if (_enemyHealth < 0 )
            {
                //Death();
            }
        }
    }


    /// <summary>
    /// Death also has to based on the object, either player or enemy
    /// </summary>
    /// <param name="loggerInterface"></param>
    public void Death(ILoggerInterface loggerInterfaces)
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");

        for (int i = 0; i < enemies.Length; i++)
        {
            Destroy(enemies[i]);
        }
    }
}
