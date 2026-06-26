using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject[] weaponPickups;
    public Animator animator;

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

        // Uruchamia animację otwierania
        animator.SetTrigger("Open");

        Debug.Log("Skrzynia otwarta!");
    }

    // Wywoływane przez Animation Event
    public void SpawnWeapon()
    {
        int randomIndex = Random.Range(0, weaponPickups.Length);

        Instantiate(
            weaponPickups[randomIndex],
            transform.position + Vector3.right,
            Quaternion.identity);
    }

    // Wywoływane przez Animation Event na końcu animacji
    public void DestroyChest()
    {
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