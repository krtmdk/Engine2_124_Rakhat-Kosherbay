using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameData gameData;
    [SerializeField] private CharacterFactory characterFactory;

    private ScoreSystem scoreSystem;

    private float gameSessionTime;
    private bool isGameActive;

    public static GameManager Instance { get; private set; }

    public CharacterFactory CharacterFactory => characterFactory;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Initialize();
        }
        else
        {
            Destroy(this.gameObject); 
        }
    }

    private void Initialize()
    {
        scoreSystem = new ScoreSystem();
        isGameActive = false;
    }

    public void StartGame()
    {
        if (isGameActive)
            return;

        Character player = characterFactory.GetCharacter(CharacterType.Player);
        player.transform.position = Vector3.zero;
        player.gameObject.SetActive(true);
        player.Initialize();
        player.LiveComponent.OnCharacterDeath += CharacterDeathHandler;

        gameSessionTime = 0;

        scoreSystem.StartGame();

        isGameActive = true;
    }

    private void Update()
    {
        if (!isGameActive)
            return;

        gameSessionTime += Time.deltaTime;
        

        if (gameSessionTime >= gameData.SessionTimeSeconds)
        {
            GameVictory();
        }
    }

    private void CharacterDeathHandler(Character deathCharacter)
    {
        switch(deathCharacter.CharacterType)
        {
            case CharacterType.Player:
                GameOver();
                break;

            case CharacterType.DefaultEnemy:
                scoreSystem.AddScore(deathCharacter.CharacterData.ScoreCost);
                break;
        }

        deathCharacter.gameObject.SetActive(false);
        characterFactory.ReturnCharacter(deathCharacter);

        deathCharacter.LiveComponent.OnCharacterDeath -= CharacterDeathHandler;

    }

    private void SpawnEnemy()
    {
        Character enemy = characterFactory.GetCharacter(CharacterType.DefaultEnemy);
        Vector3 playerPosition = characterFactory.Player.transform.position;
        enemy.transform.position = new Vector3(playerPosition.x + GetOffset(), 0, playerPosition.z + GetOffset());
        enemy.gameObject.SetActive(true);
        enemy.Initialize();
        enemy.LiveComponent.OnCharacterDeath += CharacterDeathHandler;




        float GetOffset()
        {
            bool isPlus = Random.Range(0, 100) % 2 == 0;
            float offset = Random.Range(gameData.MinSpawnOffSet, gameData.MaxSpawnOffSet);
            return (isPlus) ? offset : (-1 * offset);
        }
    }

    private void GameVictory ()
    {
        scoreSystem.EndGame();
        Debug.Log("Victory");
        isGameActive = false;   
    }

    private void GameOver ()
    {
        scoreSystem.EndGame();
        Debug.Log("Defeat");
        isGameActive = false;
    }
}
