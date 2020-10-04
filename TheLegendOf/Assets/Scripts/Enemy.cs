using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int life = 2;

    private Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    public void LoseLife(int attackDamage)
    {
        life -= attackDamage;
        if(life <= 0)
        {
            Destroy(gameObject);
        }
    }
}