using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    public Transform target;
    public Animator animator;
    


    // Start is called before the first frame update
    void Start()
    {
      this.animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    public void Update()
    {
        agent.SetDestination(target.position);
        animator.SetFloat("Speed", agent.velocity.magnitude); 
       
    }
}
