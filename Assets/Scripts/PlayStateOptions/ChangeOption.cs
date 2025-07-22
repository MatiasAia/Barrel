using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeOption : UIButton
{
    [SerializeField] GameObject CloseMenu;
    [SerializeField] GameObject NextMenu;
    [SerializeField] bool cameraChange;
    [SerializeField, ShowIf("cameraChange")] CameraManager.Positions pos;
    public override void Press()
    {

    }

    public override void Release()
    {
        if (cameraChange)
            WorldControl.control.ChangeCameraPos(pos);
        
        CloseMenu.SetActive(false);
        if (NextMenu)
            NextMenu.SetActive(true);
    }

    public override void Exit()
    {
    }
}
