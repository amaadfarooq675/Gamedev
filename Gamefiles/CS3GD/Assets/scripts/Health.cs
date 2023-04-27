using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 


public class Health : MonoBehaviour
{
    private Camera camera;

    public Image health;
    public float maxHealth;
    public float currentHealth;
    private zombieManager zombie;
    public bool enemyType;
    private CivillianManager civillian; 

    public void DamageDealt(int damage)
    {
        currentHealth -= damage;
        UpdateHealthBar();
        if (currentHealth <= 0)
        {
            if(enemyType == true) { 
            zombie.SetPlayerKillCount(1);
           
            }
            else
            {
                civillian.SetPlayerKillCount(-1);
            }

            Destroy(gameObject);
        }
    
    }

    public void UpdateHealthBar()
    {

        health.fillAmount = currentHealth / maxHealth;
    }

    public void Start()
    {
       
        UpdateHealthBar();
        camera = Camera.main;
        if (enemyType)
        {
            this.zombie = GetComponent<zombieManager>();
        }
        else
        {
            this.civillian = GetComponent<CivillianManager>();
        }
    }

    public void Update(){

        health.transform.rotation = Quaternion.LookRotation(health.transform.position - camera.transform.position); 
        

    }


}
