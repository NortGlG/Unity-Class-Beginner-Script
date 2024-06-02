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
    public bool isAlive;

    // private
    private bool isRun;
    private float Speed;
    private Vector3 moveDirection;
    private Animator animator;

    // Start Here
    void Start() {
        characterController = transform.GetComponent<CharacterController>();
        animator = PlayerModel.GetComponent<Animator>();
        isAlive = true;
    }
    public void TriggerAnimation(string index){
        animator.SetBool("isIdle", false);
        animator.SetBool("isWalk", false);
        animator.SetBool("isRun", false);
        animator.SetBool(index, true);
    }
    void Update() {
        if(!isAlive) return;
        if(Input.GetButton("Run")){ Speed = RunSpeed; isRun = true;}
        else { Speed = WalkSpeed; isRun = false;}
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
            if(isRun) TriggerAnimation("isRun");
            else TriggerAnimation("isWalk");
            Quaternion targetRotation = Quaternion.LookRotation(move);
            PlayerModel.transform.rotation = Quaternion.Lerp(PlayerModel.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        else TriggerAnimation("isIdle");
    }
    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Damager")){
            int damage = collision.transform.GetComponent<DamagerBehavior>().DamageValue;
            GameManager.Instance.UpdateHealth(damage, false);
        }
    }
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Score")){
            GameManager.Instance.UpdateScore(5);
            Destroy(other.gameObject);
        }
    }
}
