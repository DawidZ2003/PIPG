using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 1f;
    public LayerMask enemyLayer;

    public int damage = 1;
    public string currentWeapon = "Fists";
    public int weaponDurability = 999;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    void Attack()
    {
        Collider2D[] hitEnemies =
            Physics2D.OverlapCircleAll(
                attackPoint.position,
                attackRange,
                enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>()
                ?.TakeDamage(damage);
        }

        if (currentWeapon != "Fists")
        {
            weaponDurability--;

            Debug.Log("Weapon: " + currentWeapon + " | Durability: " + weaponDurability);

            if (weaponDurability <= 0)
            {
                currentWeapon = "Fists";
                damage = 1;
                weaponDurability = 999;

                Debug.Log("Broń się zepsuła! Walczysz pięściami.");
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.DrawWireSphere(
            attackPoint.position,
            attackRange);
    }
}