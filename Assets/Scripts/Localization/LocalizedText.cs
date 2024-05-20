using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LocalizedText : MonoBehaviour
{
    /// <summary>
    /// Tag del texto localizado.
    /// </summary>
    public string key;

    private TextMeshProUGUI text;

    public bool updateEveryFrame;

    public bool asignedOnStart = true;

    /// <summary>
    /// Apenas comienza, arranca una corutina que se fija si esta cargado el diccionario. 
    /// </summary>
    void Awake()
    {
        StopAllCoroutines();
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        if (asignedOnStart)
            StartCoroutine(CheckIfReady());
    }

    private void OnEnable()
    {
        StopAllCoroutines();
        text = GetComponent<TextMeshProUGUI>();
        StartCoroutine(CheckIfReady());
    }

    private void Update()
    {
        if (updateEveryFrame)
            SetText();
    }

    /// <summary>
    /// Una vez que el diccionario esta cargado, pasa a setear el texto.
    /// </summary>
    /// <returns></returns>
    IEnumerator CheckIfReady()
    {
        Debug.Log("Chequeo que el json este cargao");
        while (!LocalizationManager.instance.GetIsReady())
            yield return null;
        SetText();
    }

    /// <summary>
    /// Establece el texto localizado que corresponde a la key, en el componente de Text.
    /// </summary>
    public void SetText()
    {
        SetText(key);
    }

    /// <summary>
    /// Establece el texto localizado que corresponde a la key, en el componente de Text.
    /// </summary>
    public void SetText(string newKey)
    {
        text.text = LocalizationManager.instance.GetLocalizedValue(newKey);
        LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
    }
}


