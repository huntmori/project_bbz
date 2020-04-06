using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTrigger : MonoBehaviour {

    private void OnControllerColliderHit(ControllerColliderHit other)
    {
        if(other.gameObject.tag=="Projectile")
            Destroy(other.gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Projectile")
        {
            
        }
            
    }
}
