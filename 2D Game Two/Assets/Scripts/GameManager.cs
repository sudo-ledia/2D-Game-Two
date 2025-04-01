using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float enemyTimer = 0f;
    public float spawnInterval = 1f;

    public float enemyTimer2 = 0f;
    public float spawnInterval2 = 1f;

    public Vector2 xBounds;
    public Vector2 yBounds;

    public GameObject enemy;
    public GameObject targetEnemy;

    public int enemyCounter = 0;

    public int spawnLimit;

    private void Awake()
    {
        if(Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        enemyTimer += Time.deltaTime;
        enemyTimer2 += Time.deltaTime;

        Vector3 targetPos = new Vector3(
            Random.Range(xBounds.x, xBounds.y),
            Random.Range(yBounds.x, yBounds.y),
            0);

        if (enemyTimer >= spawnInterval && enemyCounter < spawnLimit)
        {
            enemyTimer = 0f;
            Instantiate(enemy, targetPos, Quaternion.identity);
            enemyCounter++;
        }
        else if (enemyTimer >= spawnInterval)
        {
            enemyTimer = 0f;
        }

        if (enemyTimer2 >= spawnInterval2 && enemyCounter < spawnLimit)
        {
            enemyTimer2 = 0f;
            Instantiate(targetEnemy, targetPos, Quaternion.identity);
            enemyCounter++;
        }

        else if (enemyTimer2 >= spawnInterval2)
        {
            enemyTimer2 = 0f;
        }
    }
}
