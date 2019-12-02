using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objMoveFB : MonoBehaviour
{
    public float Speed = 10.0f;
    public float WhereTo = 15;
    private bool isForward = true;
    Vector3 currentPosition, initialPosition, endPosition;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        endPosition = transform.position;
        endPosition.z = initialPosition.z - WhereTo;
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = transform.position;
        if (currentPosition.z < endPosition.z)
        {
            isForward = false;
        }
        if (currentPosition.z > initialPosition.z)
        {
            isForward = true;
        }

        if (isForward == true)
        {
            transform.Translate(Vector3.back * Time.deltaTime * Speed);
        }
        else
        {
            transform.Translate(Vector3.forward * Time.deltaTime * Speed);
        }
    }
}