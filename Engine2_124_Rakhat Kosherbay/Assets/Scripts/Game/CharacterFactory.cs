using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFactory : MonoBehaviour
{
    [SerializeField] private Character playerCharacterPrefab;
    [SerializeField] private Character enemyCharacterPrefab;

    private Dictionary<CharacterType, Queue<Character>> disabledCharacter 
        = new Dictionary<CharacterType, Queue<Character>>(); 

    private List<Character> activeCharacters = new List<Character>();


    public Character Player
    {
        get; private set;
    }

    public List<Character> ActiveCharacters => activeCharacters;

    public Character GetCharacter(CharacterType type)
    {
        Character character = null;

        if (disabledCharacter.ContainsKey(type))
        {
            if (disabledCharacter[type].Count > 0)
            {
                character = disabledCharacter[type].Dequeue();
            }
        }
        else
        {
            disabledCharacter.Add(type, new Queue<Character>());
        }

        if (character == null)
        {
            character = InstantiateCharacter(type);
        }

        activeCharacters.Add(character);
        return character;
    }

    public void ReturnCharacter(Character character)
    {
        Queue<Character> characters = disabledCharacter[character.CharacterType];
        characters.Enqueue(character);

        activeCharacters.Remove(character);
    }

    private Character InstantiateCharacter(CharacterType type)
    {
        Character character = null;
        switch (type)
        {
            case CharacterType.Player:
                character = GameObject.Instantiate(playerCharacterPrefab, null);
                Player = character;
                break;

            case CharacterType characterType:
                character = GameObject.Instantiate(enemyCharacterPrefab, null);
                break;

            default:
        }

        return character;
    }
}
