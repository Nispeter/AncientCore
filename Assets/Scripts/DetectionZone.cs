using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionZone : MonoBehaviour
{
    
    public List<Collider2D> detectedObjs;
    public string tagTarget = "Player";
    [SerializeField] private Collider2D col;

    void Start(){
        col.GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == tagTarget)
            detectedObjs.Add(other);
    }

    private void OnTriggerExit2D(Collider2D other) {
        //if(other.tag != "Player")
        detectedObjs.Remove(other);
    }
}
