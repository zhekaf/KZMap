using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slider : MonoBehaviour
{
    public Transform Player;
    public Transform forcePoint;

    private void OnTriggerEnter(Collider other)
    {

        other.GetComponent<Rigidbody>().AddForce(-transform.forward *100, ForceMode.Force);

    }

    private void OnTriggerExit(Collider other)
    {

        other.GetComponent<Rigidbody>().AddForce(transform.forward *100);

    }
}
