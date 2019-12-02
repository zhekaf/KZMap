using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{

    Transform cameraT;
    float turnSmoothVelocity;
    public float turnSmoothTime = 0.2f;
    CharacterController colider;
    public float jumpHeight = 2f;
    public float gravity = -14f;
    float velocityY;
    [SerializeField]
    private GameObject rightArm;
    [SerializeField]
    private GameObject leftArm;
    [SerializeField]
    private GameObject rightLeg;
    [SerializeField]
    private GameObject leftLeg;
    //private float rotationSpeed = 3.0f;
    public Rigidbody rb;

    void Start()
    {
        cameraT = Camera.main.transform;
        colider = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerController();

    }

    void PlayerController()
    {
         Vector3 playerController = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
         Vector3 pControl = playerController.normalized;
         if (pControl != Vector3.zero)
         {
             float targetRotation = Mathf.Atan2(pControl.x, pControl.z) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
             transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
         }
         float speed = 10 * playerController.magnitude;
         Vector3 velocity = transform.forward * speed + Vector3.up * velocityY;
         colider.Move(velocity * Time.deltaTime);
         velocityY += Time.deltaTime * gravity;
         if (colider.isGrounded)
         {
             velocityY = 0;
         }
         if (Input.GetKeyDown(KeyCode.Space))
         {
             Jump();
         }
       /* if (!colider.isGrounded)
        {
  
            Vector3 rLeg = new Vector3(-25f+ transform.eulerAngles.x, 0f+ transform.eulerAngles.y, 0f+ transform.eulerAngles.z);
            Vector3 lLeg = new Vector3(20f+ transform.eulerAngles.x, 0f+ transform.eulerAngles.y, 0f+ transform.eulerAngles.z);
            Vector3 rArm = new Vector3(0f+ transform.eulerAngles.x, 0f+ transform.eulerAngles.y, 90f+ transform.eulerAngles.z);
            Vector3 lArm = new Vector3(0f+ transform.eulerAngles.x, 0f+ transform.eulerAngles.y, -90f+ transform.eulerAngles.z);

            RotateLimb(rightArm, rArm);
            RotateLimb(leftArm, lArm);
            RotateLimb(rightLeg, rLeg);
            RotateLimb(leftLeg, lLeg);
        }
        else
        {

            Vector3 rLeg = new Vector3( transform.eulerAngles.x,  transform.eulerAngles.y,  transform.eulerAngles.z);
            Vector3 lLeg = new Vector3( transform.eulerAngles.x,  transform.eulerAngles.y,  transform.eulerAngles.z);
            Vector3 rArm = new Vector3( transform.eulerAngles.x,  transform.eulerAngles.y,  transform.eulerAngles.z);
            Vector3 lArm = new Vector3( transform.eulerAngles.x,  transform.eulerAngles.y,  transform.eulerAngles.z);

            RotateLimb(rightArm, rArm);
            RotateLimb(leftArm, lArm);
            RotateLimb(rightLeg, rLeg);
            RotateLimb(leftLeg, lLeg);
        }*/

        if(rb.position.y < 2.5f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

        if (rb.position.z > 130f)
        {
            FindObjectOfType<GameManager>().GoodGame();
        }
    }

    void Jump()
    {
         if (colider.isGrounded)
         {
             float jumpVelocity = Mathf.Sqrt(-2 * gravity * jumpHeight);
             velocityY = jumpVelocity;
         }
    }

   /* private void RotateLimb(GameObject limb, Vector3 limbTargetAngle)
    {
        Quaternion limbRot = limb.transform.localRotation;
        Vector3 limbRotEuler = limbRot.eulerAngles;
        if (!Mathf.Approximately(limbRotEuler.x, limbTargetAngle.x) && !Mathf.Approximately(limbRotEuler.y, limbTargetAngle.y) && !Mathf.Approximately(limbRotEuler.z, limbTargetAngle.z))
        {
            Vector3 deltaAngle = new Vector3(limbTargetAngle.x - limbRotEuler.x, limbTargetAngle.y - limbRotEuler.y, limbTargetAngle.z - limbRotEuler.z);

           //Vector3 localRotationAxis = limb.transform.InverseTransformVector(Vector3.right);

            limb.transform.Rotate(deltaAngle * rotationSpeed * Time.deltaTime, Space.World);
           // limb.transform.Rotate(deltaAngle.y * rotationSpeed * Time.deltaTime, Space.World);
           // limb.transform.Rotate(deltaAngle.z * rotationSpeed * Time.deltaTime, Space.World);


        }
    }*/
}
