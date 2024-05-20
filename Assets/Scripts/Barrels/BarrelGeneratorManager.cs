using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BarrelGeneratorManager : MonoBehaviour
{
    public Transform[] startBarrelsPivot;
    public Transform[] endBarrelsPivot;
    public Pool barrelsPool;
    // Start is called before the first frame update

    Coroutine generator;

    public void StartGenerator()
    {
        generator = StartCoroutine(StartingGame());
    }


    IEnumerator StartingGame()
    {
        while (true)
        {
            int barrelsPosition = UnityEngine.Random.Range(0, 3);
            Barrel barrel = barrelsPool.GetPooledObject().GetComponent<Barrel>();
            barrel.SetBarrel(startBarrelsPivot[barrelsPosition],endBarrelsPivot[barrelsPosition], Math.Round(Equations.BarrelsLife()));
            barrel.StartBarrel();
            yield return new WaitForSeconds(Equations.TimeRegenerateBarrels());
        }

    }

    public void StopGenerator()
    {
        StopCoroutine(generator);
    }

}
