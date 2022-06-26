using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{

    [SerializeField] float moveSpeed = 5f;
    Rigidbody2D rb2d;
    Transform target;
    Vector2 moveDirection;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        target = FindObjectOfType<playerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            //rb2d.rotation = angle;
            moveDirection = direction;
        }
    }

    private void FixedUpdate()
    {
        if (target)
        {
            rb2d.velocity = new Vector2(moveDirection.x, moveDirection.y * moveSpeed * Time.deltaTime);
        }
    }
}
