using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemy2 : MonoBehaviour
{
public GameObject enemy;
private void Start()
{
     StartCoroutine(spawnEnemy());
     GameObject Enemy = Instantiate(enemy, transform.position, transform.rotation);
     Enemy.SetActive(true);
}

IEnumerator spawnEnemy(){
    while(true){
    yield return new WaitForSeconds(15f);
    GameObject Enemy = Instantiate(enemy, transform.position, transform.rotation);
     Enemy.SetActive(true);
    }
}
}

