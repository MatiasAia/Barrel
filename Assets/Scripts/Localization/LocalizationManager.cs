using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Lenguages
{
    En,
    Sp,
    JP
}

public class LocalizationManager : MonoBehaviour
{
    /// <summary>
    /// Necesario para volverlo un singleton.
    /// </summary>
    public static LocalizationManager instance;

    /// <summary>
    /// Determina si se cargaron bien los datos del diccionario.
    /// </summary>
    private bool isReady = false;

    /// <summary>
    /// Mensaje para cuando no se encuentra el texto a localizar.
    /// </summary>
    private string missingTextString = "localized text not found";

    /// <summary>
    /// Diccionario que contiene la key y el texto traducido.
    /// </summary>
    private Dictionary<string, string> localizedText = new Dictionary<string, string>();

    public TextAsset[] localizations;

    Lenguages lenguage = Lenguages.En;

    /// <summary>
    /// Se asegura de que es la unica instancia del objeto y luego carga por defecto el diccionario en ingles.
    /// </summary>
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        SetLenguage(Lenguages.En);
    }

    [ContextMenu("SetSpanish")]
    public void SetSpanish()
    {
        SetLenguage(Lenguages.Sp);
    }

    public void ChangueLenguage()
    {
        lenguage = (Lenguages)(((int)lenguage + 1) % System.Enum.GetValues(typeof(Lenguages)).Length);
        SetLenguage(lenguage);
    }

    public void SetLenguage(Lenguages lenguage)
    {
        this.lenguage = lenguage;
        LoadLocalizedText(localizations[(int)lenguage]);
    }

    /// <summary>
    /// Carga el diccionario.
    /// </summary>
    /// <param name="fileName"></param>
    public void LoadLocalizedText(TextAsset textAsset)
    {
        //Pasamos el string que fue creado a partir del json al tipo de dato serializable.
        LoadingData(JsonUtility.FromJson<LocalizationData>(textAsset.text));

        //Se termino la carga.
        isReady = true;
    }

    /// <summary>
    /// Busca en el diccionario y devuelve el texto requerido. De no obtenerlo, devuelve el mensaje de missing text.
    /// </summary>
    /// <param name="key">Tag del texto buscado.</param>
    /// <returns>Texto traducido o texto de "Traduccion no encontrado".</returns>
    public string GetLocalizedValue(string key)
    {
        string result = missingTextString;
        if (localizedText.ContainsKey(key))
        {
            result = localizedText[key];
        }
        return result;
    }

    /// <summary>
    /// Devuelve el estado del cargado.
    /// </summary>
    /// <returns></returns>
    public bool GetIsReady()
    {
        return isReady;
    }

    /// <summary>
    /// Carga los datos dependiendo cada arreglo que contiene la clase contenedora de los datos.
    /// </summary>
    /// <param name="loadedData"></param>
    public void LoadingData(LocalizationData loadedData)
    {
        Debug.Log("cargue el json");
        localizedText.Clear();

        //Cargamos todo al diccionario de los botonoes.
        for (int i = 0; i < loadedData.items.Length; i++)
            localizedText.Add(loadedData.items[i].key, loadedData.items[i].value);
    }
}