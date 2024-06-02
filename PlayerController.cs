using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    // public
    public float WalkSpeed = 4f;
    public float RunSpeed = 8f;
    public float JumpForce = 2;
    public float Gravity = 1;
    public GameObject PlayerModel;
    public CharacterController characterController;
    public float rotationSpeed = 10f;

    // private
    private float Speed;
    private Vector3 moveDirection;

    // Start Here
    void Start() {
        characterController = transform.GetComponent<CharacterController>();
    }

    void Update() {
        if(Input.GetButton("Run")) Speed = RunSpeed;
        else Speed = WalkSpeed;
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = -Input.GetAxisRaw("Vertical");
        Vector3 moveInput = new Vector3(verticalInput, 0, horizontalInput).normalized;
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.z;
        moveDirection.x = moveInput.x * Speed;
        moveDirection.z = moveInput.z * Speed;
        if(characterController.isGrounded){
            if(Input.GetButtonDown("Jump")){
                moveDirection.y = JumpForce;
            }
        }
        else{
            moveDirection.y -= Gravity * Time.deltaTime;
        }
        characterController.Move(moveDirection * Time.deltaTime);

        if(move != Vector3.zero){
            Quaternion targetRotation = Quaternion.LookRotation(move);
            PlayerModel.transform.rotation = Quaternion.Lerp(PlayerModel.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Damager")){
            GameManager.Instance.UpdateHealth(10);
        }
    }
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Score")){
            GameManager.Instance.UpdateScore(5);
            Destroy(other.gameObject);
        }
    }
}
