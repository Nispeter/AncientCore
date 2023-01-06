using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public ContactFilter2D movementFilter; 
    public SwordAttack swordAttack;  

    public float movementSpeed = 1f;                                     
    public float collisionOffset = 0.05f;

    Vector2 movementInput; 
    SpriteRenderer spriteRenderer;                                
    Rigidbody2D rb;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    Animator animator;

    [SerializeField] private bool lockedRotation = false;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate(){
        if(movementInput != Vector2.zero){

            bool success = TryMove(movementInput);
            if(!success && movementInput.x > 0)
                success =  TryMove( new Vector2(movementInput.x,0));  
            if(!success && movementInput.y > 0 )
                    success =  TryMove( new Vector2(0,movementInput.y));

            animator.SetBool("isMovingRight", success);
        }
        else
            animator.SetBool("isMovingRight", false);

        if(!lockedRotation){
            if(movementInput.x < 0){
                spriteRenderer.flipX = true;
                //swordAttack.attackDirection = SwordAttack.AttackDirection.left;
            }
            else if(movementInput.x > 0){
                spriteRenderer.flipX = false;
                //swordAttack.attackDirection = SwordAttack.AttackDirection.right;
            }
        }
        
    }

    private bool TryMove(Vector2 direction){
        if(direction != Vector2.zero){
            int count = rb.Cast(
                    direction,
                    movementFilter,
                    castCollisions,
                    movementSpeed * Time.fixedDeltaTime * collisionOffset);
            if(count == 0){
                rb.MovePosition(rb.position + direction * movementSpeed * Time.fixedDeltaTime);
                return true;
            }
            else 
                return false;
        }
        else return false;
    }

     private void SetSpeedOnAttack(bool active){
        if(active) movementSpeed *= 1/2f;
        else movementSpeed *= 2f;
    }

    public void LockRotation(){
        lockedRotation = true;
        SetSpeedOnAttack(lockedRotation);
    }
   
    public void UnlockRotation(){
        lockedRotation = false;
        SetSpeedOnAttack(lockedRotation);
    }

    public void SwordAttack(){
        LockRotation();
        if(spriteRenderer.flipX == true)
            swordAttack.AttackLeft();
        else 
        swordAttack.AttackRight();
    }

    void OnMove(InputValue movementValue){                  
        movementInput = movementValue.Get<Vector2>();
    }

    void OnFire(){
        animator.SetTrigger("swordAttack");
    }
}

internal class CharacterAnimator{
    [SerializeField] private int _currentState;
    [SerializeField] private float _lockTime  = 0.0f;
    [SerializeField] private float _swordAnimTime  = 0.4f;

    private static readonly int Walk = Animator.StringToHash("Player_walk_right");
    private static readonly int Idle = Animator.StringToHash("Player_idle_front");
    private static readonly int Attack = Animator.StringToHash("Player_attack_right");
}