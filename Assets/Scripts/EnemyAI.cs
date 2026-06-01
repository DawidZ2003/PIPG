using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    enum State
    {
        Idle,
        Chase,
        Attack
    }

    State currentState = State.Idle;

    public Transform player;
    public float detectionRange = 5f;
    public float attackRange = 1f;
    public float moveSpeed = 2f;

    public int damage = 1;
    public float attackCooldown = 1f;

    private float lastAttackTime;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= attackRange)
            currentState = State.Attack;
        else if (distance <= detectionRange)
            currentState = State.Chase;
        else
            currentState = State.Idle;
    }

    void FixedUpdate()
    {
        switch (currentState)
        {
            case State.Idle:
                rb.linearVelocity = Vector2.zero;
                break;

            case State.Chase:
                Vector2 direction = (player.position - transform.position).normalized;
                rb.linearVelocity = direction * moveSpeed;
                break;

            case State.Attack:
                rb.linearVelocity = Vector2.zero;
                TryAttackPlayer();
                break;
        }
    }

    void TryAttackPlayer()
    {
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

            if (playerHealth == null)
            {
                Debug.LogError("Player nie ma skryptu PlayerHealth!");
                return;
            }

            Debug.Log("Enemy zadaje obrażenia!");
            playerHealth.TakeDamage(damage);
            lastAttackTime = Time.time;
        }
    }
}