using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemy1 : MonoBehaviour
{
public GameObject enemy;
private void Start()
{
     GameObject Enemy = Instantiate(enemy, transform.position, transform.rotation);
     Enemy.SetActive(true);
}
}
