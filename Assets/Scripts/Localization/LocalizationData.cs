/// <summary>
/// Arreglo necesario para poder serializar un diccionario.
/// </summary>
[System.Serializable]
public class LocalizationData
{
    /// <summary>
    /// Array of localization types.
    /// </summary>
    public LocalizationItem[] items;

    /// <summary>
    /// Types of localization
    /// </summary>
    public enum Types
    {
        #region In this block of code there are the localization types enumerated.

        Texts,

        #endregion
    }
}

/// <summary>
/// Representacion del diccionario.
/// </summary>
[System.Serializable]
public struct LocalizationItem
{
    public string key;
    public string value;
}