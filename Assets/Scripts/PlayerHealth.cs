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
        LockHealth();
        Health-=damage;   
        print("hit, health = " + health);
    }

    public void OnHit(float damage, Vector2 knockBack){

    }

    public void LockHealth(){
        if(lockHealth){
            lockHealth = false;
        }
        else 
            lockHealth = true;
    }

    public void OnHit(float damage){
        if(!lockHealth)
            TakeDamage(damage);
        
    }

    public void Defeat(){
        Destroy(gameObject);
    }

}
