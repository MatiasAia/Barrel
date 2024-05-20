using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterMovement : CharacterComponent
{

    [SerializeField]
    Transform[] pivots;

    public AnimationCurve curve;

    bool isMoving;

    Coroutine checkingInputs;

#if UNITY_ANDROID
    Vector2 inicioPosicion = Vector2.zero;
    Vector2 finPosicion = Vector2.zero;
    float minDeslizamientoDistancia = 20f;
#endif

    enum Position : int
    {
        Left,
        Mid,
        Right
    }

    Position currentPosition = Position.Mid;

    void Start()
    {
        transform.position = pivots[(int)currentPosition].position;
        
    }

    public void StartMovement()
    {
        
    }

    IEnumerator CheckInputs()
    {
        while (true)
        {
#if UNITY_ANDROID
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                
                if (touch.phase == TouchPhase.Began)
                {
                    inicioPosicion = touch.position;
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    finPosicion = touch.position;

                    float deslizamientoDistanciaX = finPosicion.x - inicioPosicion.x;

                    if (Math.Abs(deslizamientoDistanciaX) > minDeslizamientoDistancia)
                    {
                        Debug.Log(deslizamientoDistanciaX);
                        if (deslizamientoDistanciaX > 0)
                        {
                            MoveCharacter(true);
                        }
                        else
                        {
                            MoveCharacter(false);
                        }
                        // Determina la dirección del deslizamiento
                        float deslizamientoX = finPosicion.x - inicioPosicion.x;
                       
                        Debug.Log("Deslizamiento detectado");
                    }
                }
            }
#endif
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                MoveCharacter(false);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                MoveCharacter(true);
            }

            yield return null;
        }
    }

    void MoveCharacter(bool isRight)
    {
        if (!ItsPossible(isRight) || isMoving)
            return;

        isMoving = true;

        StartCoroutine(MovingCharacter(isRight));

    }

    IEnumerator MovingCharacter(bool isRight)
    {
        float time = 0;

        Vector3 currentPositionAux = transform.position;

        currentPosition = currentPosition + (isRight ? 1 : -1);

        while (time< Equations.CharacterSpeed())
        {
            transform.position = Vector3.Lerp(currentPositionAux, pivots[(int)currentPosition].position, curve.Evaluate(time / Equations.CharacterSpeed()));
            time += Time.deltaTime;
            yield return null;
        }

        transform.position = pivots[(int)currentPosition].position;

        isMoving = false;
    }

    bool ItsPossible(bool isRight)
    {
        return isRight ? (int)currentPosition + 1 < Enum.GetValues(typeof(Position)).Length : (int)currentPosition - 1 >= 0;
    }

    public override void Die()
    {
        StopCoroutine(checkingInputs);
    }

    public override void Restart()
    {
        
    }

    public override void Starting()
    {
        checkingInputs = StartCoroutine(CheckInputs());
    }

    public override void DieByWall()
    {
        StopCoroutine(checkingInputs);
    }
}
