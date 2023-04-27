using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Safezone : MonoBehaviour
{

    
    [SerializeField]
    bool touchingPlayer;
    public GameObject UIelement;
    public Transform safeZoneTarget; 
    //public int ignoreLayers; 

    // Start is called before the first frame update
    void Start()
    {
        //  
    }

    // Update is called once per frame
   //void Update()
   //{
   //
   //    if ( touchingPlayer)
   //    {
   //       
   //        Debug.Log("civillians change target");
   //        touchingPlayer = false;
   //    }
   //}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerManager>().safeZonePointer(safeZoneTarget); 
            touchingPlayer = true;
            UIelement.SetActive(true);

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            touchingPlayer = false;
            UIelement.SetActive(false);
        }
    }

}