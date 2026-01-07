using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character
{
    [SerializeField] private PlayerInputReader inputReader;


    public override Character CharacterTarget
    {
        get
        {
            Character target = null;
            float minDistance =float.MaxValue;
            List<Character> list = GameManager.Instance.CharacterFactory.ActiveCharacters;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].CharacterType == CharacterType.Player) 
                    continue;

                float distanceBetween = Vector3.Distance(list[i].transform.position, transform.position);
                if (distanceBetween < minDistance)
                {
                    target = list[i];
                    minDistance = distanceBetween;
                }
            }

            return target;
        }
    }

    public override void Initialize()
    {
        base.Initialize();

        LiveComponent = new PlayerLiveComponent();
        LiveComponent.Initialize(this);

        AttackComponent = new CharacterAttackComponent();
        AttackComponent.Initialize(this);
    }

    public override void Update()
    {
        if (LiveComponent == null || !LiveComponent.IsAlive) return;

        Vector3 movementVector = Vector3.zero;
        if (inputReader != null)
            movementVector = inputReader.GetMovementDirection();

        if (CharacterTarget == null)
        {
            MovableComponent.Rotation(movementVector);
        }
        else
        {
            Vector3 rotationDirection = CharacterTarget.transform.position - transform.position;
            MovableComponent.Rotation(movementVector);

            if (Input.GetButtonDown("Jump"))
            AttackComponent.MakeDamage(CharacterTarget);
        }

            MovableComponent.Move(movementVector);
       
    }
}
