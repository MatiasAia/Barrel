using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressLevel : MonoBehaviour
{
    public static ProgressLevel control;

    int quantityBarrels = 1;
    int wallHealt = 0;
    int currentMoney = 0;
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

    public int GetBarrels()
    {
        return quantityBarrels;
    }

    public void UpBarrels()
    {
        quantityBarrels++;
    }

    public void Restart()
    {
        quantityBarrels = 1;
        wallHealt = 100;
    }

    public void RecoletMoney(int quantity)
    {
        currentMoney += quantity;
    }
}
