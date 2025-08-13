using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyUpgradeOption : UIButton
{
    [SerializeField] int cost;
    [SerializeField] int firstCost;
    [SerializeField] ProgressManager.PlayerData.WeaponType weaponType;
    [SerializeField] ProgressManager.PlayerData.WeaponFeature weaponFeature;

    private void Start()
    {
        cost = (int)Equations.Cost(firstCost, weaponType, weaponFeature);
        Debug.Log("Costo" + cost + " firstCost " + firstCost);
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
            GameControl.instance.SetData(weaponType, weaponFeature, 1);
            GameControl.instance.Save();
            UpdateTextManager.instance.UpdateAllText();
            cost = (int)Equations.Cost(firstCost, weaponType, weaponFeature);
        }
    }
}
