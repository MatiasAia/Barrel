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

    public void RestartGame()
    {
        characterManager.DesactivateUI();
        characterManager.RestartComponents();
        ProgressLevel.control.Restart();
    }

    [ContextMenu("StartGame")]
    public void StartGame()
    {
        characterManager.StartComponents();
        barrelGenerator.StartGenerator();
        ProgressLevel.control.SetLevel();
    }

    public void EndGame()
    {
        cameraManager.ChangePos(CameraManager.Positions.PlayerDead);
        barrelGenerator.StopGenerator();
        ProgressLevel.control.SendMoney();
        GameControl.instance.Save();
    }

    public void EndGameByDestroyWall()
    {
        cameraManager.ChangePos(CameraManager.Positions.CityDestroyed);
        barrelGenerator.StopGenerator();
        characterManager.DiebyWall();
    }

    public void ChangeCameraPos(CameraManager.Positions pos)
    {
        cameraManager.ChangePos(pos);
    }


}
