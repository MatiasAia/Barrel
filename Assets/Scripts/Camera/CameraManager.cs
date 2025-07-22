using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraManager : MonoBehaviour
{
    public Transform cameraGO;
    public Transform[] cameraPivots;
    public LabeledFloat[] times;//TODO: cameraPivots debe estar dentro de times
    public Transform character;

    public enum Positions
    {
        InitPos,
        PlayerPos,
        PlayerDead,
        CityDestroyed,
        Shop, 
        City,
        Cannon
    }

    public void ChangePos(Positions position)
    {
        StartCoroutine(ChangingPos(position));
    }

    IEnumerator ChangingPos(Positions position)
    {
        Vector3 aux = cameraGO.position;
        Quaternion auxAngle = cameraGO.rotation;
        float time = 0;
        while (time < times[(int)position].TimeToPosition)
        {
            cameraGO.position = Vector3.Lerp(aux, cameraPivots[(int)position].position, times[(int)position].curve.Evaluate(time / times[(int)position].TimeToPosition));
            cameraGO.rotation = Quaternion.Lerp(auxAngle, cameraPivots[(int)position].rotation, times[(int)position].curve.Evaluate(time / times[(int)position].TimeToPosition));

            time += TimeManager.control.GetTime();
            yield return null;
        }

        cameraGO.position = cameraPivots[(int)position].position;
        cameraGO.eulerAngles = cameraPivots[(int)position].eulerAngles;

        switch (position)
        {
            case Positions.PlayerPos:
                cameraGO.parent = character;
                break;
            case Positions.InitPos:
            case Positions.Shop:
            case Positions.PlayerDead:
            case Positions.Cannon:
            case Positions.CityDestroyed:
                cameraGO.parent = null;
                break;
            default:
                break;
        }
    }

    private void OnValidate()
    {
        for (int i = 0; i < times.Length; i++)
        {
            times[i].name = Enum.GetNames(typeof(Positions))[i];
        }
    }

    [System.Serializable]
    public class LabeledFloat
    {
        [HideInInspector]
        public string name;
        public float TimeToPosition;
        public AnimationCurve curve;
    }
}





