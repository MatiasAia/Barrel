using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityManager : MonoBehaviour
{
    public int wallLife;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ReduceLife()
    {
        wallLife--;
        if (wallLife <= 0)
            WorldControl.control.EndGameByDestroyWall();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("choco barril");
        ReduceLife(); 
    }
}
