using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float health = 6f;
    Animator animator;

    public float Health{
        set{
            health = value;
            if(health <= 0 ){
                print("ded");
                Defeated();
            }
        }
        get{
            return health;
        }
    }
    
    void Start(){
        animator = GetComponent<Animator>();
    }
    
    public void TakeDamage(float damage){
        Health = Health - damage;
    }

    public void Defeated(){
        animator.SetTrigger("Defeated"); 
    }

    public void Death(){
        Destroy(gameObject);
    }
}
