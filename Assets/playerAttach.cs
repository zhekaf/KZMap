using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttach : MonoBehaviour
{
    public Transform Player;
    public Transform rotatePoint;

    private void OnTriggerEnter(Collider other)
    {
        
            other.transform.position = Player.position + transform.position;
        
    }

    private void OnTriggerExit(Collider other)
    {
       
            other.transform.position = Player.position;
       
    }
}
