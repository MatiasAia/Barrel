using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeOption : UIButton
{
    [SerializeField] GameObject CloseMenu;
    [SerializeField] GameObject NextMenu;
    public override void Press()
    {

    }

    public override void Release()
    {
        CloseMenu.SetActive(false);
        if (NextMenu)
            NextMenu.SetActive(true);
    }

    public override void Exit()
    {
    }
}
