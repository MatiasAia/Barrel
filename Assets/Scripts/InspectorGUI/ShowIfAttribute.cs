using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowIfAttribute : PropertyAttribute
{
    public string condicion;

    public ShowIfAttribute(string condicion)
    {
        this.condicion = condicion;
    }
}
