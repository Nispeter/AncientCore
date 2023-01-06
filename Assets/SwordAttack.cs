using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public enum AttackDirection{
        left,right
    }
    public AttackDirection attackDirection;

    [SerializeField] private Vector2 rightAttackOffset;
    [SerializeField] private Collider2D swordCollider;
    
    private void FStart(){
        swordCollider = GetComponent<Collider2D>();
        rightAttackOffset = transform.position;
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
        transform.position = rightAttackOffset;
    }
    public void AttackLeft(){
        swordCollider.enabled = true;
        transform.position = new Vector2(rightAttackOffset.x * -1, rightAttackOffset.y);
    }
    public void StopAttack(){
        swordCollider.enabled = false;
    }
}
