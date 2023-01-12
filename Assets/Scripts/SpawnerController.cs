using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float enemyInterval = 6f;
    [SerializeField] private float range = .2f;
    [SerializeField] private Transform t;
    
    void Start(){
        t = gameObject.transform;
        StartCoroutine(SpawnEnemy(enemyInterval, enemyPrefab));
    }

    private IEnumerator SpawnEnemy(float interval, GameObject enemy){
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, t.position + new Vector3(Random.Range(-range,range),Random.Range(-range,range),0), Quaternion.identity);    
        enemyInterval -= 0.1f;
        StartCoroutine(SpawnEnemy(interval, enemy)); 
    }
    
}
