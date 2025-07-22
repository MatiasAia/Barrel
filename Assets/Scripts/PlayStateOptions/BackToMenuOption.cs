using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMenuOption : UIButton
{
    public override void Press()
    {

    }

    public override void Release()
    {
        LoadingManager.instance.LoadScene(Utilities.MAIN_MENU_SCENE);
    }
    public override void Exit()
    {

    }
}
