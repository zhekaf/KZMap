using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objMoveRL : MonoBehaviour
{
    public float Speed = 4.0f;
    public float WhereTo = 10;
    private bool isForward = true;
    Vector3 currentPosition, initialPosition, endPosition;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        endPosition = transform.position;
        endPosition.x = initialPosition.x + WhereTo;
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = transform.position;
        if (currentPosition.x > endPosition.x)
        {
            isForward = false;
        }
        if (currentPosition.x < initialPosition.x)
        {
            isForward = true;
        }

        if (isForward == true)
        {
            transform.Translate(Vector3.right * Time.deltaTime * Speed);
        }
        else
        {
            transform.Translate(Vector3.left * Time.deltaTime * Speed);
        }
    }
}