using UnityEngine;
using System.Collections;

public class MyEnemyManager : MonoBehaviour
{
    public int enemySpawnTime = 3;
    public Transform[] enemyTransform;
    public GameObject[] enemy;

    void Start()
    {
        InvokeRepeating("EnemySpawn", enemySpawnTime, enemySpawnTime);
    }

    void EnemySpawn()
    {
        int i =  Random.Range(0, enemyTransform.Length);

        GameObject enemygo = (GameObject)Instantiate(enemy[i], enemyTransform[i].position, enemyTransform[i].rotation);
        enemygo.AddComponent<MyEnemyHealth>();
        enemygo.AddComponent<MyEnemyAttack>();
        enemygo.AddComponent<MyEnemyMovement>();
    }
}
