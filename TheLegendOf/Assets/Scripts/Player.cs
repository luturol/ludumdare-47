using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] GameObject body;
    [SerializeField] float life = 2f; 
    
    private Vector2 movement;
    private Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;
    private Vector2 mouse;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = body.GetComponent<SpriteRenderer>();
        Camera.main.GetComponent<CameraFollow>().SetFollowPlayer();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (mouse.x < transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
        else if (mouse.x > transform.position.x)
        {
            spriteRenderer.flipX = false;
        }
    }

    void FixedUpdate()
    {
        rigidbody2D.MovePosition(rigidbody2D.position + movement * movementSpeed * Time.fixedDeltaTime);
    }

    public void LoseLife(int attackDamage, Characters attackOwner)
    {
        life -= attackDamage;
        if (life <= 0)
        {
            SceneLoader.currentCharacter = attackOwner;
            Debug.Log(SceneLoader.currentCharacter);
            Destroy(gameObject);
            FindObjectOfType<SceneLoader>().LoadStartScene();
        }
    }
}