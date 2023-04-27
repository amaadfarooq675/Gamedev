using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
  
    private Rigidbody bulletRigidbody; 

    private void Awake(){
        bulletRigidbody = GetComponent<Rigidbody>(); 
    }

    private void Start(){
        float speed = 20f; 
        bulletRigidbody.velocity = transform.forward * speed; 
    }

    private void OnTriggerEnter(Collider other){
        Destroy(gameObject);
        if (other.gameObject.CompareTag("enemy") || other.gameObject.CompareTag("civillian"))
        {
            other.gameObject.GetComponent<Health>().DamageDealt(20);
        }

            
            
        
    }

}
