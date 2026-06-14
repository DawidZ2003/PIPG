using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject[] weaponPickups;

    private bool playerNearby;
    private bool opened;

    void Update()
    {
        if (playerNearby && !opened && Input.GetKeyDown(KeyCode.E))
        {
            OpenChest();
        }
    }

    void OpenChest()
    {
        opened = true;

        int randomIndex = Random.Range(0, weaponPickups.Length);

        Instantiate(
            weaponPickups[randomIndex],
            transform.position + Vector3.right,
            Quaternion.identity);

        Debug.Log("Skrzynia otwarta!");
        
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerNearby = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerNearby = false;
    }
}