using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownController : MonoBehaviour
{
    Transform myTransform;

    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private float turnSpeed;

    [SerializeField]
    private GameObject camera;

    private CameraMovement cameraMvmt;

    private Animator animator;

    private void Start()
    {

        animator = GetComponentInChildren<Animator>();
        if (camera != null)
        {
            cameraMvmt = camera.GetComponent<CameraMovement>();
        }
        myTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        Vector3 movementDir = new Vector3(Horizontal, 0, Vertical);
        movementDir = camera.transform.TransformDirection(movementDir);
        movementDir.y = 0;
        transform.position += movementDir;

        if (Horizontal != 0 || Vertical != 0)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movementDir);
            transform.rotation = targetRotation;

            animator.SetBool("isMoving", true);

        }
        else
        {
            animator.SetBool("isMoving", false);

        }
    }

    void LateUpdate()
    {
       if (cameraMvmt != null)
        {
            cameraMvmt.CameraPosition(myTransform.position);
        }
    }

    
}
