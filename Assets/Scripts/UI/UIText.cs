using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class UIText : MonoBehaviour
{
    protected TextMeshProUGUI text;

    [SerializeField] protected ProgressManager.Data dataType;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    protected virtual void Start()
    {
        if (GameControl.instance)
            SetText(GameControl.instance.GetData(dataType));
    }

    protected virtual void OnEnable()
    {
        if(GameControl.instance)
            SetText(GameControl.instance.GetData(dataType));
    }

    protected virtual void SetText(long playerData) { }
}
