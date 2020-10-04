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
    void Start()
    {
        DestroyProjectile();
    }

    // Update is called once per frame
    void Update()
    {
        // RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.right, distance);
        // if (hitInfo.collider != null)
        // {
        //     if (hitInfo.collider.CompareTag(enemyTag))
        //     {
        //         Debug.Log("Enemy has taken damage");
        //         hitInfo.collider.gameObject.GetComponent<Enemy>().LoseLife(attackDamage);
        //         Destroy(gameObject);
        //     }
        // }
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void DestroyProjectile()
    {
        Destroy(gameObject, lifeTime);
    }

    public void SetEnemyTag(string enemy)
    {
        enemyTag = enemy;
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().LoseLife(attackDamage);
            Destroy(gameObject);
        }
    }

}
