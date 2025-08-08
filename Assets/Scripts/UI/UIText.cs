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

    void Start()
    {
        UpdateText();
    }

    void OnEnable()
    {
        if(UpdateTextManager.instance)
            UpdateTextManager.instance.setAllText += UpdateText;

        UpdateText();
    }

    private void OnDisable()
    {
        if (UpdateTextManager.instance)
            UpdateTextManager.instance.setAllText -= UpdateText;
    }

    protected virtual void SetText(long playerData) { }

    protected virtual void UpdateText()
    {
        if (GameControl.instance)
            SetText(GameControl.instance.GetData(dataType));
    }
}
