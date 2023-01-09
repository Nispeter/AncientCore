using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public enum AttackDirection{
        left,right
    }
    public AttackDirection attackDirection;

    [SerializeField] private Collider2D swordCollider;
    [SerializeField] private bool lastAttackRight = false;
    [SerializeField] private bool lastAttackLeft = false;
    
    private void FStart(){
        swordCollider = GetComponent<Collider2D>();
    }
    public void Swing(){
        switch (attackDirection)
        {
            case AttackDirection.left:
                AttackLeft();
                break;
            case AttackDirection.right:
                AttackRight();
                break;
            //default:
        }
    }
    public void AttackRight(){
        swordCollider.enabled = true;
        if(lastAttackLeft)  transform.localPosition = new Vector2 (transform.localPosition.x*-1 , transform.localPosition.y);
        lastAttackRight = true;
        lastAttackLeft = false;
    }
    public void AttackLeft(){
        swordCollider.enabled = true;
        if(lastAttackRight){
            transform.localPosition = new Vector2(transform.localPosition.x*-1 ,transform.localPosition.y);
        } 
        lastAttackRight = false;
        lastAttackLeft = true;
    }
    public void StopAttack(){
        swordCollider.enabled = false;
    }
}
