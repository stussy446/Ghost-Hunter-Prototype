using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] float healthPoints = 1f;
    [SerializeField] float damageTaken = 1f;
    [SerializeField] float damageDelay = .2f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        TakeDamage();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        TakeDamage();
    }


    void TakeDamage()
    {
       
        healthPoints -= damageTaken;
        GetComponent<SpriteRenderer>().color = Color.red;
        Invoke("DestroyOnNoHealth", damageDelay); ;
        
    }


    // if the objects healthpoints reach 0, destroy the object 
    void DestroyOnNoHealth()
    {
        if (healthPoints <= float.Epsilon)
        {
            if (gameObject.transform.parent != null && gameObject.layer != LayerMask.GetMask("Enemies"))
            {
                Destroy(transform.parent.gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            
        }
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
