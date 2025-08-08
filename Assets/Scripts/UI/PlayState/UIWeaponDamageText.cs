using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWeaponDamageText : UIText
{
    public ProgressManager.PlayerData.WeaponType weaponType;

    protected override void SetText(long playerData)
    {
        text.text = playerData.ToString();
    }

    protected override void UpdateText()
    {
        if (GameControl.instance)
            SetText(GameControl.instance.GetData(weaponType));
    }

}
