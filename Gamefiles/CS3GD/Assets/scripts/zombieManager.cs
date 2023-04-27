using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieManager : MonoBehaviour
{
    private Movement movement;
    private Health health;
    private Animator animator;
    public bool cooldown = false;
    public float radius;
    public LayerMask targetMask;
    public bool followingCivillian;
    public bool inSafeZone;
    public PlayerManager playertarget; 
    // Start is called before the first frame update
    void Start()
    {
        this.movement = GetComponent<Movement>();
        this.health = GetComponent<Health>();
        this.animator = GetComponent<Animator>();
        
    }

    public void attack()
    {
        StartCoroutine(Delay()); 
        

    }
    public void Update()
    {

        CollisionChecker();
        if ( movement.target == null && cooldown == false)
        {
            float Distance = Vector3.Distance(this.transform.position, movement.target.position);
            if (Distance <= 0.8f)
            {
                StopAllCoroutines(); 
                attack();
            }
        
        }
    }

    IEnumerator Delay()
    {
        animator.SetTrigger("Attack");
        cooldown = true;
        yield return new WaitForSeconds(3);
        cooldown = false;

    }

    public void SetPlayerKillCount(int number)
    {
       playertarget.SetPlayerKillCount(number); 
    }

    public void CollisionChecker()
    {
        // Overlap sphere around the enemy to detect the playermask in the view radius
        Collider[] civillians = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (civillians.Length > 0 && followingCivillian == false)
        {
            Transform civillian = civillians[0].transform;
            GetComponent<Movement>().target = civillian;
            followingCivillian = true;
        }
        }
    }

