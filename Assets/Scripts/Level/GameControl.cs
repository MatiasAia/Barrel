using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// Encargado de brindar información del progreso del jugador
public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    [SerializeField] ProgressManager progressManager;

    private void Awake()
    {
        progressManager.Load();

        if (instance == null)
            instance = this;
    }

    public void Save()
    {
        progressManager.Save();
    }

    public long GetData(ProgressManager.Data data)
    {
        switch (data)
        {
            case ProgressManager.Data.WallHealt:
                return progressManager.playerData.wallHealt;
            case ProgressManager.Data.Money:
                return progressManager.playerData.money;
            case ProgressManager.Data.CannonProgress:
                return progressManager.playerData.cannonProgress;
            case ProgressManager.Data.CannonLevel:
                return progressManager.playerData.cannonLevel;
            case ProgressManager.Data.GorilaLevel:
                return progressManager.playerData.gorilaLevel;
            case ProgressManager.Data.BarrelsLevel:
                return progressManager.playerData.barrelsLevel;
        }
        return 0;
    }


    public long GetData(ProgressManager.PlayerData.WeaponType weaponType)
    {
         return progressManager.playerData.weaponsInfo[weaponType];
    }

    public void SetData(ProgressManager.Data dataType, int quantity)
    {
        switch (dataType)
        {
            case ProgressManager.Data.WallHealt:
                progressManager.playerData.wallHealt += quantity;
                break;
            case ProgressManager.Data.Money:
                progressManager.playerData.money += quantity;
                break;
            case ProgressManager.Data.CannonProgress:
                progressManager.playerData.cannonProgress += quantity;
                break;
            case ProgressManager.Data.CannonLevel:
                progressManager.playerData.cannonLevel += quantity;
                break;
            case ProgressManager.Data.GorilaLevel:
                progressManager.playerData.gorilaLevel += quantity;
                break;
            case ProgressManager.Data.BarrelsLevel:
                progressManager.playerData.barrelsLevel = quantity;
                break;
        }
    }

    public void SetData(ProgressManager.PlayerData.WeaponType weaponType, int quantity)
    {
        progressManager.playerData.weaponsInfo[weaponType] += quantity;
    }


    public void SetData(ProgressManager.Data dataType, long quantity)
    {
        switch (dataType)
        {
            case ProgressManager.Data.BarrelsLevel:
                progressManager.playerData.barrelsLevel = quantity;
                break;
        }
    }

}
