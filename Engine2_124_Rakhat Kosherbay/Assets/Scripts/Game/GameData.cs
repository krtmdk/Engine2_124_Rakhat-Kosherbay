using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData")]
public class GameData :ScriptableObject
{
    [SerializeField] private int sessionTimeMinutes = 15;
    [SerializeField] private float timeBetweenEnemySpawn = 1.5f;
    [SerializeField] private float minSpawnOffSet = 7;
    [SerializeField] private float maxSpawnOffSet = 18;
    [SerializeField] private int startMaxEnemies = 3;
    [SerializeField] private int enemiesPerMinute = 1;

    public int SessionTimeMinutes => sessionTimeMinutes;
    public int SessionTimeSeconds => sessionTimeMinutes * 60;

    public float TimeBetweenEnemySpawn => timeBetweenEnemySpawn;
    public float MinSpawnOffSet => minSpawnOffSet;
    public float MaxSpawnOffSet => maxSpawnOffSet;
    public int StartMaxEnemies => startMaxEnemies;
    public int EnemiesPerMinute => enemiesPerMinute;
}
