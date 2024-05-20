using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraManager : MonoBehaviour
{
    public Transform cameraGO;
    public Transform[] cameraPivots;
    public LabeledFloat[] times;
    public Transform character;

    public enum Positions
    {
        Pos1,
        Pos2,
        Pos3,
        Pos4
    }

    public void ChangePos(Positions position)
    {
        StartCoroutine(ChangingPos(position));
    }

    IEnumerator ChangingPos(Positions position)
    {
        Vector3 aux = cameraGO.position;
        Vector3 auxAngle = cameraGO.eulerAngles;
        float time = 0;
        while (time < times[(int)position].TimeToPosition)
        {
            cameraGO.position = Vector3.Lerp(aux, cameraPivots[(int)position].position, times[(int)position].curve.Evaluate(time / times[(int)position].TimeToPosition));
            cameraGO.eulerAngles = Vector3.Lerp(auxAngle, cameraPivots[(int)position].eulerAngles, times[(int)position].curve.Evaluate(time / times[(int)position].TimeToPosition));

            time += TimeManager.control.GetTime();
            yield return null;
        }

        cameraGO.position = cameraPivots[(int)position].position;
        cameraGO.eulerAngles = cameraPivots[(int)position].eulerAngles;

        switch (position)
        {
            case Positions.Pos1:
                break;
            case Positions.Pos2:
                cameraGO.parent = character;
                break;
            case Positions.Pos3:
            case Positions.Pos4:
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





