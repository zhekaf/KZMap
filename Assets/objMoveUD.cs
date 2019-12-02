using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objMoveUD : MonoBehaviour
{
    public float Speed = 4.0f;
    public float WhereTo = 20;
    private bool isForward = true;
    Vector3 currentPosition, initialPosition, endPosition;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        endPosition = transform.position;
        endPosition.y = initialPosition.y - WhereTo;
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = transform.position;
        if (currentPosition.y < endPosition.y)
        {
            isForward = false;
        }
        if (currentPosition.y > initialPosition.y)
        {
            isForward = true;
        }

        if (isForward == true)
        {
            transform.Translate(Vector3.down * Time.deltaTime * Speed);
        }
        else
        {
            transform.Translate(Vector3.up * Time.deltaTime * Speed);
        }
    }
}