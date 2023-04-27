using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivillianManager : MonoBehaviour
{

    public float radius;
    public LayerMask targetMask;
    public bool followingPlayer;
    public bool inSafeZone;
    private Movement movement;
    public PlayerManager player; 



    public void CollisionChecker()
    {
        // Overlap sphere around the enemy to detect the playermask in the view radius
        Collider[] players = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (inSafeZone == false) {
            if (players.Length > 0 && followingPlayer == false)
            {
                players[0].gameObject.GetComponentInParent<PlayerManager>().AddCivillian(this.gameObject);
                Transform player = players[0].transform;


                GetComponent<Movement>().target = player;
                followingPlayer = true;

            }
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {

        this.movement = GetComponent<Movement>();

    }
    public void SetPlayerKillCount(int number)
    {
        player.SetPlayerKillCount(-1); 
    }

    // Update is called once per frame
    void Update()
    {
        CollisionChecker(); 
    }


    public void changeTarget(Transform target)
    {
        GetComponent<Movement>().target = target;
        followingPlayer = false;
        inSafeZone = true; 
    }
}
