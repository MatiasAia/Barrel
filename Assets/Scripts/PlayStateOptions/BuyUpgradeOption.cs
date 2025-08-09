using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyUpgradeOption : UIButton
{
    [SerializeField] int cost;
    [SerializeField] int firstCost;
    [SerializeField] ProgressManager.PlayerData.WeaponType weaponType = ProgressManager.PlayerData.WeaponType.Pistol;

    private void Start()
    {
        cost = (int)Equations.Cost(firstCost, weaponType);
        Debug.Log("Costo" + cost);
    }

    public override void Exit()
    {
        
    }

    public override void Press()
    {
        
    }

    public override void Release()
    {
        if(GameControl.instance.GetData(ProgressManager.Data.Money) > cost)
        {
            GameControl.instance.SetData(ProgressManager.Data.Money, -cost);
            GameControl.instance.SetData(ProgressManager.PlayerData.WeaponType.Pistol, 1);
            GameControl.instance.Save();
            UpdateTextManager.instance.UpdateAllText();
            cost = (int)Equations.Cost(firstCost, weaponType);
        }
    }
}
