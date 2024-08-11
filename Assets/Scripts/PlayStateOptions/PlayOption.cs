using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOption : UIButton
{

    public override void Press()
    {

    }

    public override void Release()
    {
        WorldControl.control.StartGame();
    }

    public override void Exit()
    {

    }
}
