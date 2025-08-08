using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressLevel : MonoBehaviour
{
    public static ProgressLevel control;

    long levelBarrels;
    int wallHealt = 0;
    [SerializeField] int currentMoney = 0;
    City city;
    public City CityReference
    {
        get => city;

        set => city = value;
    }
    // Start is called before the first frame update
    void Awake()
    {
        control = this;
    }

    private void Start()
    {
        levelBarrels = GameControl.instance.GetData(ProgressManager.Data.BarrelsLevel);
        SetLevel();
    }

    public void SetLevel()
    {
        wallHealt = 10;
        CityReference.Set();
    }

    public int GetWallHealt()
    {
        return wallHealt;
    }

    public long GetBarrels()
    {
        return levelBarrels;
    }

    public void UpBarrels()
    {
        levelBarrels++;
    }

    public void Restart()
    {
        GameControl.instance.SetData(ProgressManager.Data.BarrelsLevel, levelBarrels);
        wallHealt = 100;
    }

    public void SendMoney()
    {
        GameControl.instance.SetData(ProgressManager.Data.Money, currentMoney);
    }


    public void RecoletMoney(int quantity)
    {
        currentMoney += quantity;
        Debug.Log("Money:" + currentMoney);
    }
}
