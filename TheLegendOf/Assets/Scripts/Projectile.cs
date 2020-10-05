using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifeTime = 2f;
    public float speed = 5f;
    public float distance;
    public LayerMask whatIsSolid;
    public int attackDamage = 1;
    // Start is called before the first frame update

    private string enemyTag = string.Empty;
    private Characters attackOwner;
    private Transform player;
    private Vector2 target;
    private bool rotate = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
        DestroyProjectile();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyTag == "Enemy")
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else if (enemyTag == "Player")
        {
            if (!rotate)
            {
                Vector3 lookDirection = player.transform.position - transform.position;
                Debug.Log(lookDirection);
                float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0f, 0f, angle);
                rotate = true;
            }

            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

            if (transform.position.x == target.x && transform.position.y == target.y)
                Destroy(gameObject);
        }
    }

    private void DestroyProjectile()
    {
        Destroy(gameObject, lifeTime);
    }

    public void SetEnemyTag(string enemy)
    {
        enemyTag = enemy;
    }

    public void SetAttackOwner(Characters owner)
    {
        attackOwner = owner;
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {        
        if (other.gameObject.tag == enemyTag && enemyTag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().LoseLife(attackDamage);
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == enemyTag && enemyTag == "Player")
        {
            other.gameObject.GetComponent<Player>().LoseLife(attackDamage, attackOwner);
            Destroy(gameObject);
        }
    }
}
