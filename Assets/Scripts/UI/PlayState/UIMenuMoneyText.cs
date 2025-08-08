using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenuMoneyText : UIText
{
    protected override void SetText(long money)
    {
        text.text = money.ToString();
    }
}
