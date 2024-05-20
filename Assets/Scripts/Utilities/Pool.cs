using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
	public GameObject pooledObject; // El objeto a poolear
	public int pooledAmount; // la cantidad minima con la que empeiza el pool
	public bool willGrow = true; // determina si el pool crece a demanda o no

	public List<GameObject> pooledObjects; // lista que contiene los objetos pooleados

	// Configuracion inicial
	void Start()
	{
		pooledObjects = new List<GameObject>();
		for (int i = 0; i < pooledAmount; i++)
		{
			GameObject obj = (GameObject)Instantiate(pooledObject);
			obj.gameObject.SetActive(false);
			obj.transform.SetParent(transform, false);
			pooledObjects.Add(obj);
		}
	}

	public void Clear()
	{
		pooledObjects.Clear();
	}

	// Funcion llamada por ribboncreator cuando necesita un ribbon
	public GameObject GetPooledObject()
	{

		// Si encuentra un ribbon disponible lo envia
		for (int i = 0; i < pooledObjects.Count; i++)
		{
			if (!pooledObjects[i].gameObject.activeInHierarchy)
			{
				pooledObjects[i].gameObject.SetActive(true);
				return pooledObjects[i];
			}
		}

		// Si no lo encuentra, y el pool crece a demanda
		// crea uno nuevo y lo envia
		if (willGrow)
		{
			GameObject obj = (GameObject)Instantiate(pooledObject);

			obj.gameObject.SetActive(true);
			obj.transform.SetParent(transform, false);
			pooledObjects.Add(obj);
			return obj;
		}

		// Sino, devuelve nada
		return null;
	}

	public void TurnOff()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
			pooledObjects[i].SetActive(false);
        }
    }
}
