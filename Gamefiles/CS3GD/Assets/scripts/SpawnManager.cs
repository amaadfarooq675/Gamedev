using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemyRB;
    public bool cooldown = false;
    public float radius;
    public LayerMask targetMask;
    public bool followingCivillian;
    public bool inSafeZone;
    public PlayerManager playertarget;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemyRB, transform.position, transform.rotation);
    }

    // Update is called once per frame
    
    
    
    
    void Update()
    {
        
    }
}
