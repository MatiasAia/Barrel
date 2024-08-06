using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuButton : UIButton
{
    public override void Press()
    {

    }

    public override void Release()
    {
        LoadingManager.instance.LoadScene(Utilities.PLAYSTATE_SCENE);
    }
    public override void Exit()
    {

    }
}
