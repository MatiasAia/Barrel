using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseOption : UIButton
{
    public override void Press()
    {
    }

    public override void Release()
    {
        WorldControl.control.RestartGame();
    }

    public override void Exit()
    {
    }
}
