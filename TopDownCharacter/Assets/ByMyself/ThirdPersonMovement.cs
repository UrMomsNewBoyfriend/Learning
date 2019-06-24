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

    bool isAttacking = false;
    bool isSprinting = false;

    void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isAttacking = true;
            animator.SetTrigger("Attack");

        }
    }

    public void AttackEnd()
    {
        isAttacking = false;
    }

    void Sprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            movementSpeed = 10f;
            isSprinting = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            movementSpeed = 3f;
            isSprinting = false;
            
        }
    }


    
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    
    void Update()
    {
        if (isAttacking == false) {
            float Horizontal = Input.GetAxis("Horizontal");
            float Vertical = Input.GetAxis("Vertical");

            Vector3 movementDir = new Vector3(Horizontal, 0, Vertical);
            movementDir = camera.transform.TransformDirection(movementDir);
            movementDir.y = 0;
            transform.position += movementDir * movementSpeed * Time.deltaTime;

            if (Horizontal != 0 || Vertical != 0)
            {
                Quaternion targetRotattion = Quaternion.LookRotation(movementDir);
                transform.rotation = targetRotattion;
                float speed = movementDir.magnitude;
                if (isSprinting == false && speed > 0.5f)
                {
                    speed = 0.5f;
                }
                animator.SetFloat("speed", speed);
            }
            
        }

        Attack();
        Sprint();


    }
}
