using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeManager : MonoBehaviour
{
    public static FadeManager instance;

    [SerializeField] FadeEffect fadeEffect;

    public FadeEffect FadeEffect { get => fadeEffect; set { fadeEffect = value; } }

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Fade(FadeEffect.fadeProccess fadeProccess, bool isIn, float timeToWait = 0)
    {
        fadeEffect.Fade(fadeProccess, isIn, timeToWait);
    }

    public bool GetInFading()
    {
        return fadeEffect.InFading;
    }
}
