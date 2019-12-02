using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float angle= 0;
    // Start is called before the first frame update
    void Start()
    {
        rotateLimb();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = new Vector3(20f, 0f, 0f);
        transform.eulerAngles += temp * Time.deltaTime;
    }
    void rotateLimb()
    {
        //Quaternion limb = transform.localRotation;
        //Vector3 limbEuler = limb.eulerAngles;
       
    }
}
