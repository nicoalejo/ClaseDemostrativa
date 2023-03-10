using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private EnemyController enemy;     //Variable que contiene el script ligado al gameobject del enemigo a spawnear 
    [SerializeField] private float spawnInterval = 2f;  //Cada cuantos segundos spawnea un nuevo enemigo

    private float _nextSpawnTime = 0;

    void Update()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        if (Time.time <= _nextSpawnTime) return;

        _nextSpawnTime = Time.time + spawnInterval;
        
        //Se instancia un nuevo enemigo usando el gameobject referido en la variable enemy,
        //como posición para la instancia se usa el componente transform del Gameobject
        //donde esta asignado el script Spawner
        Instantiate(enemy, transform);
    }
}
