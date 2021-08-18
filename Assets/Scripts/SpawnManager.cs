using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject[] powerUps;
    //spawn enemy using coroutine function

    private void Start()
    {
       StartCoroutine(EnemySpawn());
        StartCoroutine(SpawnPowerUP());
    }

    IEnumerator EnemySpawn()
    {
        while (true)
        {
            Instantiate(enemyPrefab, new Vector3(Random.Range(-8.0f, 8.0f), 6.0f, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }
    IEnumerator SpawnPowerUP()
    {
        while (true)
        {
            int randomePowerUp = Random.Range(0, powerUps.Length);
            Instantiate(powerUps[randomePowerUp], new Vector3(Random.Range(-8.0f, 8.0f), 6.0f, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }
}
