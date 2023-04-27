using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public int killCount;
    public TMP_Text killScore;
    public List<GameObject> civillians = new List<GameObject>();
    //public LayerMask civillianCollision;

    void Start()
    {
        killScore.text = "SCORE: " + killCount.ToString();
        Physics.IgnoreLayerCollision(7, 6 );
    }


    public void SetPlayerKillCount(int number)
    {
        killCount+= number;
        killScore.text = "SCORE: " + killCount.ToString();
        Debug.Log(killCount.ToString());

    }

    public void AddCivillian(GameObject civillian)
    {
        civillians.Add(civillian); 
    }

    public void DeleteCivillian(GameObject civillian)
    {
        civillians.Remove(civillian); 
    }

    

  public void safeZonePointer(Transform target)
  {
        foreach (GameObject civillian in civillians)
        {
            civillian.GetComponent<CivillianManager>().changeTarget(target);
            //DeleteCivillian(civillian); 

        }
      {
  
      }
  }
    
}
