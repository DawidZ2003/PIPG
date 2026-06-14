using UnityEngine;

public class HealthUI : MonoBehaviour
{
    public PlayerHealth playerHealth;

    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    void Update()
    {
        heart1.SetActive(playerHealth.currentHealth >= 1);
        heart2.SetActive(playerHealth.currentHealth >= 2);
        heart3.SetActive(playerHealth.currentHealth >= 3);
    }
}