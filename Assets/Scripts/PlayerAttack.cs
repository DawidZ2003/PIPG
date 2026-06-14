using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 1f;
    public LayerMask enemyLayer;

    public int damage = 1;
    public string currentWeapon = "Fists";
    public int weaponDurability = 0;
    public bool hasWeapon = false;

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

        if (hasWeapon)
        {
            weaponDurability--;

            if (weaponDurability <= 0)
            {
                currentWeapon = "Fists";
                damage = 1;
                weaponDurability = 0;
                hasWeapon = false;

                Debug.Log("Broń się zepsuła!");
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