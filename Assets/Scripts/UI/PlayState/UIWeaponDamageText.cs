using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWeaponDamageText : UIText
{
    [SerializeField] ProgressManager.PlayerData.WeaponType weaponType;

    [SerializeField] bool cost;

    [SerializeField] int firstPrice;

    protected override void SetText(long playerData)
    {
        text.text = playerData.ToString();
    }

    protected override void UpdateText()
    {
        if(!cost)
        {
            if (GameControl.instance)
                SetText(GameControl.instance.GetData(weaponType));
        }
        else
        {
            SetText(Equations.Cost(firstPrice, weaponType));
        }
    }

}
