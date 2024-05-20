using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField]
    public CharacterComponent[] components;
    public CharacterMovement characterMovement;

    public GameObject LoseUI;

    private void Start()
    {
        foreach (var item in components)
        {
            item.SetManager(this);
        }
    }

    public enum States
    {
        Die
    }

    public void Die()
    {
        foreach (CharacterComponent item in components)
            item.Die();
        WorldControl.control.EndGame();
        LoseUI.SetActive(true);
    }

    public void DiebyWall()
    {
        foreach (CharacterComponent item in components)
            item.DieByWall();
        LoseUI.SetActive(true);
    }

    public void NotifyState(States state)
    {
        switch (state)
        {
            case States.Die:
                Die();
                break;
        }
    }

    public void RestartComponents()
    {
        foreach (CharacterComponent item in components)
            item.Restart();
    }

    public void StartComponents()
    {
        foreach (CharacterComponent item in components)
            item.Starting();
    }

    public void DesactivateUI()
    {
        LoseUI.SetActive(false);
    }
}
