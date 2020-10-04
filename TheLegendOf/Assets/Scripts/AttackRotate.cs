using System.Collections.Generic;
using UnityEngine;

public class AttackRotate : MonoBehaviour
{
    public GameObject attackPrefab;
    public GameObject attackPoint;
    public float couldown = 3f;

    private Vector3 mousePosition;
    private float timeBetweenAttacks = 0;

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 lookDirection = mousePosition - transform.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        if (Input.GetButtonDown("Fire1") && timeBetweenAttacks <= 0)
        {
            var projectile = Instantiate(attackPrefab, attackPoint.transform.position, transform.rotation);
            projectile.GetComponent<Projectile>().SetEnemyTag("Enemy");
            timeBetweenAttacks = couldown;
        }
        else
        {
            timeBetweenAttacks -= Time.deltaTime;
        }
    }
}
