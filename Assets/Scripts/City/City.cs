using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour
{
    int wallLife;

    private void Awake()
    {
        ProgressLevel.control.CityReference = this;
    }

    public void Set()
    {
        wallLife = ProgressLevel.control.GetWallHealt();
    }

    public void ReduceLife(Barrel barrel)
    {
        wallLife--;
        if (wallLife <= 0)
        {
            barrel.Killer = true;
            WorldControl.control.EndGameByDestroyWall();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("choco barril");
        ReduceLife(other.GetComponent<Barrel>()); 
    }
}
