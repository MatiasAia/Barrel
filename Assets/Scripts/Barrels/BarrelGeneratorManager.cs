using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BarrelGeneratorManager : MonoBehaviour
{
    public static BarrelGeneratorManager instace;

    public Transform[] startBarrelsPivot;
    public Transform[] endBarrelsPivot;
    public Pool barrelsPool;
    // Start is called before the first frame update

    Coroutine generator;

    [SerializeField] List<IBarrel> barrels = new List<IBarrel>();

    private void Awake()
    {
        instace = this;
    }

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
            Subcribe(barrel);
            barrel.SetBarrel(startBarrelsPivot[barrelsPosition],endBarrelsPivot[barrelsPosition], Equations.BarrelsLife(ProgressLevel.control.GetBarrels()));
            barrel.StartBarrel();
            yield return new WaitForSeconds(Equations.TimeRegenerateBarrels(ProgressLevel.control.GetBarrels()));
        }
    }

    public void Subcribe(IBarrel barrel)
    {
        //Debug.Log("Sub");
        barrels.Add(barrel);
    }

    public void UnSubcribe(IBarrel barrel)
    {
        //Debug.Log("UnSub");
        barrels.Remove(barrel);
    }

    public void StopGenerator()
    {
        StopCoroutine(generator);
        DesactivateBarrels();
    }

    public void DesactivateBarrels()
    {
        IBarrel[] aux = barrels.ToArray(); //Esto es porque cuando se desuscriben se eliminan de la lista, rompiendo el for
        for (int i = 0; i < aux.Length; i++)
        {
            aux[i].FinishGame();
        }
    }

}
