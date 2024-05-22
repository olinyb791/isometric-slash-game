using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour{

    private CharacterController characterController;
    private Animator animator;

    public float moveSpeed = 7f;
    public float turnSpeed = 100.0f;
    //public Animator anim = null;

    private void Start() {
        //characterController = GetComponent<CharacterController>();
        animator = this.GetComponent<Animator>();
        transform.position = new Vector3(0, 1, 0);
    }

    private void Update() {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        if (vertical != 0) {
            animator.SetBool("isWalking",true);
        }
        else {
            animator.SetBool("isWalking", false);
        }

        this.transform.Translate(0f , 0f, vertical * moveSpeed * Time.deltaTime);
        this.transform.Rotate(0f , horizontal * turnSpeed * Time.deltaTime, 0f);
        

    }
}

/*
  Vector2 inputVector = new Vector2(0,0);
        if (Input.GetKey(KeyCode.W)) {
            inputVector.y = +1;
        }
        if (Input.GetKey(KeyCode.S)) {
            inputVector.y = -1;
        }
        if (Input.GetKey(KeyCode.A)) {
            inputVector.x = -1;
        }
        if (Input.GetKey(KeyCode.D)) {
            inputVector.x = +1;
        }

        inputVector = inputVector.normalized;

        Vector3 moveDirection = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += moveDirection * moveSpeed * Time.deltaTime;


        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);

        animator.SetBool("isWalking", Input.GetAxisRaw("Vertical") != 0);
 */ 