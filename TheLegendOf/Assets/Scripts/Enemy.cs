using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int life = 2;
    public float startTimeBetweenAttacks;

    public Projectile enemyAttack;

    private float timeBetweenAttacks;
    private Characters character;

    // Start is called before the first frame update
    void Start()
    {
        timeBetweenAttacks = startTimeBetweenAttacks;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (timeBetweenAttacks <= 0)
        {
            var player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {                
                var projectile = Instantiate(enemyAttack, transform.position, Quaternion.identity);                
                projectile.SetEnemyTag("Player");
                projectile.SetAttackOwner(character);
            }

            timeBetweenAttacks = startTimeBetweenAttacks;
        }
        else
        {
            timeBetweenAttacks -= Time.deltaTime;
        }
    }

    public void LoseLife(int attackDamage)
    {
        life -= attackDamage;
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void SetCharacter(Characters enemy)
    {
        character = enemy;
    }
}