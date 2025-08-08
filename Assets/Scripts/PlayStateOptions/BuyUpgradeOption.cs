using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyUpgradeOption : UIButton
{
    public int cost = 100;

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
        }
    }
}
