using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_01 : EnemyController
{
    public DetectionZone detectionZone;
    public float movementSpeed = 3000f;
    

    void FixedUpdate(){
       MoveToDetected() ;
    }
    
    void MoveToDetected(){
        int scanCount = detectionZone.detectedObjs.Count;
        if(scanCount > 0 && isAlive ){
            Vector2 direction = (Vector2)(detectionZone.detectedObjs[0].transform.position  - transform.position).normalized;
            rb.AddForce(direction * movementSpeed * Time.deltaTime);
        }
    }
}
