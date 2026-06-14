using TMPro;
using UnityEngine;

public class WeaponUI : MonoBehaviour
{
    public PlayerAttack playerAttack;
    public TMP_Text weaponText;

    void Update()
    {
        if(playerAttack.hasWeapon)
        {
            weaponText.text =
                "Weapon: " + playerAttack.currentWeapon +
                "\nDurability: " + playerAttack.weaponDurability;
        }
        else
        {
            weaponText.text =
                "Weapon: Fists";
        }
    }
}