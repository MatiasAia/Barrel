using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWeaponFeatureText : UIText
{
    [SerializeField] ProgressManager.PlayerData.WeaponType weaponType;

    [SerializeField] ProgressManager.PlayerData.WeaponFeature weaponFeature;

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
                SetText(Equations.WeaponDamage(GameControl.instance.GetData(weaponType, weaponFeature)));
        }
        else
        {
            SetText(Equations.Cost(firstPrice, weaponType, weaponFeature));
        }
    }

}
