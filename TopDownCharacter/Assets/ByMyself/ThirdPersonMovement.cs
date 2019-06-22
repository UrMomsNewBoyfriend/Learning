using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject camera;

    [SerializeField]
    private float movementSpeed;

    private Animator animator;


    
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    
    void Update()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        Vector3 movementDir = new Vector3(Horizontal, 0, Vertical);
        movementDir = camera.transform.TransformDirection(movementDir);
        movementDir.y = 0;
        transform.position += movementDir * movementSpeed * Time.deltaTime;

        if (Horizontal != 0 || Vertical !=0)
        {
            Quaternion targetRotattion = Quaternion.LookRotation(movementDir);
            transform.rotation = targetRotattion;

            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
    }
}
