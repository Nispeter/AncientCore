using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, I_damageble
{
    public float health = 5f;
    [SerializeField]private bool lockHealth = false;

    public float Health{
        set{
            health = value;
            if(health==0)
                Defeat();
        }  
        get {
            return health;
        } 
    }

    public void TakeDamage(float damage){
        //lockHealth();
        Health-=damage;   
        print("hit, health = " + health);
    }

    public void OnHit(float damage){

    }

    public void LockHealth(){
        if(lockHealth){
            lockHealth = false;
        }
        else 
            lockHealth = true;
    }

    Rigidbody2D rb;
    public void OnHit(float damage, Vector2 knockBack){
        if(!lockHealth){
            rb = GetComponentInParent<Rigidbody2D>();
            rb.AddForce(knockBack);
            TakeDamage(damage);
        }
    }

    public void Defeat(){
        Destroy(gameObject);
    }

}
