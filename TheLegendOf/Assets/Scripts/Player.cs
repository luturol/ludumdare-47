using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5f;

    private Vector2 movement;
    private Rigidbody2D rigidbody2D;
    private SpriteRenderer  spriteRender;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();    
        spriteRender = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        if(mouse.x < transform.position.x)
        {
            spriteRender.flipX = true;
        }
        else if(mouse.x > transform.position.x)
        {            
            spriteRender.flipX = false;
        }
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        rigidbody2D.MovePosition(rigidbody2D.position + movement * movementSpeed * Time.fixedDeltaTime);
    }    
}
