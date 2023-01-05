using UnityEngine;

public class CameraController : MonoBehaviour
{
   public Transform target;
   public float smoothSpeed = 0.1f;
   public Vector3 offset;

   private void FixedUpdate() { 
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position,desiredPosition, smoothSpeed);
        transform.position = smoothPosition; 
   }
}
