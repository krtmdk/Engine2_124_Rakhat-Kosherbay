using UnityEngine;

public class CharacterSpawnController : MonoBehaviour
{
    [SerializeField] private GameData gameData;
    [SerializeField] private CharacterFactory characterFactory;

    private float sessionTime;
    private float spawnTimer;

    private int currentMaxEnemies;

    public void StartSpawn()
    {
        sessionTime = 0f;
        spawnTimer = gameData.TimeBetweenEnemySpawn;
        currentMaxEnemies = gameData.StartMaxEnemies;
    }

    public void StopSpawn()
    {
        enabled = false;
    }

    private void Update()
    {
        sessionTime += Time.deltaTime;
        spawnTimer -= Time.deltaTime;

        UpdateMaxEnemies();

        if (spawnTimer <= 0)
        {
            TrySpawnEnemy();
            spawnTimer = gameData.TimeBetweenEnemySpawn;
        }
    }

    private void UpdateMaxEnemies()
    {
        int minutesPassed = Mathf.FloorToInt(sessionTime / 60f);
        currentMaxEnemies = gameData.StartMaxEnemies + minutesPassed * gameData.EnemiesPerMinute;
    }

    private void TrySpawnEnemy()
    {
        int currentEnemies = characterFactory.ActiveCharacters.Count - 1; // минус игрок

        if (currentEnemies >= currentMaxEnemies)
            return;

        Character enemy = characterFactory.GetCharacter(CharacterType.DefaultEnemy);

        Vector3 playerPos = characterFactory.Player.transform.position;
        enemy.transform.position = playerPos + GetRandomOffset();

        enemy.gameObject.SetActive(true);
        enemy.Initialize();
    }

    private Vector3 GetRandomOffset()
    {
        float offset = Random.Range(gameData.MinSpawnOffSet, gameData.MaxSpawnOffSet);
        float x = Random.value > 0.5f ? offset : -offset;
        float z = Random.value > 0.5f ? offset : -offset;
        return new Vector3(x, 0, z);
    }
}
