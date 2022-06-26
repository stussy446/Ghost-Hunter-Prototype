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
        healthPoints -= damageTaken;
        GetComponent<SpriteRenderer>().color = Color.red;
        Invoke("DestroyOnNoHealth", damageDelay); ;
    }

    // if the objects healthpoints reach 0, destroy the object 
    void DestroyOnNoHealth()
    {
        if (healthPoints <= float.Epsilon)
        {
            Destroy(gameObject);
        }
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
