using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public string weaponName = "Sword";
    public int damage = 2;
    public int durability = 5;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerAttack playerAttack = other.GetComponent<PlayerAttack>();

        if (playerAttack != null)
        {
            playerAttack.currentWeapon = weaponName;
            playerAttack.damage = damage;
            playerAttack.weaponDurability = durability;

            Debug.Log("Podniesiono broń: " + weaponName + 
                      " | Damage: " + damage + 
                      " | Durability: " + durability);

            Destroy(gameObject);
        }
    }
}