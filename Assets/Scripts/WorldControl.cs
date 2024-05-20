using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldControl : MonoBehaviour
{
    public static WorldControl control;
    public CameraManager cameraManager;
    public CharacterManager characterManager;
    public BarrelGeneratorManager barrelGenerator;

    private void Awake()
    {
        if (control != null)
            Destroy(this);
        else
            control = this;
    }

    public void Start()
    {
        cameraManager.ChangePos(CameraManager.Positions.Pos1);
    }

    public void RestartGame()
    {
        cameraManager.ChangePos(CameraManager.Positions.Pos1);
        characterManager.DesactivateUI();
        characterManager.RestartComponents();
    }

    public void StartGame()
    {
        cameraManager.ChangePos(CameraManager.Positions.Pos2);
        characterManager.StartComponents();
        barrelGenerator.StartGenerator();
    }

    public void EndGame()
    {
        cameraManager.ChangePos(CameraManager.Positions.Pos3);
        barrelGenerator.StopGenerator();
    }

    public void EndGameByDestroyWall()
    {
        cameraManager.ChangePos(CameraManager.Positions.Pos4);
        barrelGenerator.StopGenerator();
        characterManager.DiebyWall();
    }
}
