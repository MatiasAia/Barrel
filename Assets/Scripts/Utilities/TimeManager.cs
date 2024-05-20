using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager control;
    float barrelTime = 1;
    float bulletTime = 1;
    float gameTime = 1;

    void Awake()
    {
        // Se encarga de que sola exista una instancia de GameController y que sea esta
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    public float GetTime()
    {
        return Time.deltaTime * gameTime;
    }

    public float GetBarrelTime()
    {
        return Time.deltaTime * barrelTime * gameTime;
    }

    public float GetBulletTime()
    {
        return Time.deltaTime * bulletTime * gameTime;
    }

    

}
