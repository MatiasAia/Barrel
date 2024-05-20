using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterComponent : MonoBehaviour
{
    public CharacterManager characterManager;
    // Start is called before the first frame update
    public abstract void Die();

    public abstract void DieByWall();

    public abstract void Restart();

    public abstract void Starting();

    public void SetManager(CharacterManager characterManager)
    {
        this.characterManager = characterManager;
    }
}
