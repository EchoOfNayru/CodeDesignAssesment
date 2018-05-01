using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public int enemiesToSpawn;
    public List<CharacterBase> enemies = new List<CharacterBase>();
    public GameObject basicEnemyPrefab;
    public Transform firstSpawn;

    void Awake()
    {
        ServiceLocator.instance.enemyManager = this;

        if (enemiesToSpawn > 5)
        {
            enemiesToSpawn = 5;
        }
        else if (enemiesToSpawn < 1)
        {
            enemiesToSpawn = 1;
        }
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            GameObject spawnedEnemy = Instantiate(basicEnemyPrefab);
            spawnedEnemy.name = "Enemy " + i;
            enemies.Add(spawnedEnemy.GetComponent<CharacterBase>());
        }
    }

    void Start()
    {
        
        SpawnEnemies();
    }

    public void SpawnEnemies()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            Vector3 offset = Vector3.forward * i * -4;
            if (i > 2)
            {
                offset = (Vector3.right * 4) + Vector3.forward * (i - 2.5f) * -4;
            }
            enemies[i].transform.position = firstSpawn.position + offset;
        }
    }
}
