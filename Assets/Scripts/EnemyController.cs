using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, I_damageble
{
    public float health = 6f;
    public Rigidbody2D rb;
    public bool isAlive = true;
    Animator animator;

    public float Health{
        set{
            health = value;
            if(health <= 0 ){
                Defeated();
            }   
        }
        get{
            return health;
        }
    }
    
    void Start(){
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    } 

    public void Defeated(){
        isAlive = false;
        animator.SetTrigger("Defeated"); 
    }

    public void Death(){
        Destroy(gameObject);
    }

    public void TakeDamage(float damage){   
        Health = Health - damage;
    }

    public void OnHit(float damage, Vector2 knockBack){
        //print("hit, health = " + health);
        TakeDamage(damage);
        rb.AddForce(knockBack);
        animator.SetBool("Hit",true);
    }

    public void stopHit(){
        animator.SetBool("Hit",false);
    }

    public void OnHit(float damage){
        TakeDamage(damage);
    }

    public float dmg = 1f;
    private void OnCollisionEnter2D(Collision2D other) {        
        Collider2D temp = other.collider;
        I_damageble dmgble = temp.GetComponent<I_damageble>();
        if(dmgble != null && temp.tag == "Player"){
            dmgble.OnHit(dmg);
        }
    }
}
