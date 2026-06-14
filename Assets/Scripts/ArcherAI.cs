using UnityEngine;

public class ArcherAI : MonoBehaviour
{
    public Transform player;
    public GameObject arrowPrefab;
    public Transform shootPoint;

    public float detectionRange = 8f;
    public float shootCooldown = 2f;

    private float lastShootTime;

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= detectionRange)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (Time.time < lastShootTime + shootCooldown)
            return;

        Vector2 direction = player.position - shootPoint.position;

        GameObject arrowObject = Instantiate(
            arrowPrefab,
            shootPoint.position,
            Quaternion.identity
        );

        Arrow arrow = arrowObject.GetComponent<Arrow>();
        arrow.SetDirection(direction);

        lastShootTime = Time.time;

        Debug.Log("Archer strzela!");
    }
}