using UnityEngine;
using System;

public class UpdateTextManager : MonoBehaviour
{
    public static UpdateTextManager instance;

    public Action setAllText;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void UpdateAllText()
    {
        setAllText?.Invoke();
    }
}
