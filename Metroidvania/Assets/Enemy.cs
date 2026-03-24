using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float health;
    [SerializeField] protected float recoilLength;
    [SerializeField] protected float recoilFactor;
    [SerializeField] protected bool isRecoiling = false;

    [SerializeField] protected PlayerController player;
    [SerializeField] protected float speed;
    protected float recoilTimer;
    [SerializeField] protected float damage;
    protected Rigidbody2D rb;
    void Start()
    {
        
    }

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = PlayerController.instance;
    }

    protected virtual void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
        if(recoilTimer < recoilLength)
        {
            recoilTimer += Time.deltaTime;
        }
        else
        {
            isRecoiling = false;
            recoilTimer = 0;
        }
    }

    public virtual void EnemyHit(float _damageDone)
    {
        health -= _damageDone;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && !isRecoiling)
        {
            Attack();
        }
    }
    protected virtual void Attack()
    {
        PlayerController.instance.TakeDamage(damage);
    }
}
