using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] int money = 10;
    
    public void Set(int barrelCont)
    {
        
    }

    public void GiveMoney()
    {
        ProgressLevel.control.RecoletMoney(money);
    }
}
