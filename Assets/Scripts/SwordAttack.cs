using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public enum AttackDirection{
        left,right
    }
    public AttackDirection attackDirection;
    public Collider2D swordCollider;
    
    private void FStart(){
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
        if(transform.localScale.x < 0)  
            transform.localScale = new Vector2 (transform.localScale.x*-1 , transform.localScale.y);
    }
    public void AttackLeft(){
        swordCollider.enabled = true;
        if(transform.localScale.x > 0){
            transform.localScale = new Vector2 (transform.localScale.x*-1 , transform.localScale.y);
        } 
    }
    public void StopAttack(){
        swordCollider.enabled = false;
    }


    public float damage = 2f;
    private void  OnTriggerEnter2D(Collider2D other) {
        I_damageble damagebleObject= other.GetComponent<I_damageble>();
        if(other.tag == "Enemy" && damagebleObject != null){
            
            Vector2 kb = CalculateKnockBack(other);
            EnemyController enemy = other.GetComponent<EnemyController>();
            if(enemy != null){
                enemy.OnHit(damage,kb);
            }
        }
    }

    public float knockBackForce = 500f;
    private Vector2 CalculateKnockBack(Collider2D other){
        Vector3 parentPosition = gameObject.GetComponentInParent<Transform>().position;
        Vector3 direction = (Vector2)(-parentPosition + other.gameObject.transform.position).normalized;
        Vector2 knockBack = direction * knockBackForce;
        print(knockBack);
        return knockBack;
    }
}
