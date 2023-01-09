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
        print("hit");
        if(other.tag == "Enemy"){
            EnemyController enemy = other.GetComponent<EnemyController>();
            if(enemy != null){
                enemy.TakeDamage(damage);
            }
        }
    }
}
