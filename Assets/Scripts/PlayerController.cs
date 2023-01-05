using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public float movementSpeed = 1f;                       
    public ContactFilter2D movementFilter;                 
    public float collisionOffset = 0.05f;

    Vector2 movementInput;                                 
    Rigidbody2D rb;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    Animator animator;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate(){
        if(movementInput != Vector2.zero){
            bool success = TryMove(movementInput);
            if(!success){
                success =  TryMove( new Vector2(movementInput.x,0));
                if(!success)
                    success =  TryMove( new Vector2(0,movementInput.y));
            }
            animator.SetBool("isMovingRight",success);
        }
        else
            animator.SetBool("isMovingRight",false);
        
    }

    private bool TryMove(Vector2 direction){
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

    void OnMove(InputValue movementValue){                  
        movementInput = movementValue.Get<Vector2>();
    }
}

