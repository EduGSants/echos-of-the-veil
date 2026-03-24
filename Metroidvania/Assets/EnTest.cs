using UnityEngine;

public class EnTest : Enemy
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.gravityScale = 12f;
    }
    protected override void Awake()
    {
        base.Awake();
    }

     protected override void Update()
    {
        base.Update();
        if(!isRecoiling)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(PlayerController.instance.transform.position.x, transform.position.y), speed * Time.deltaTime);
        }
     }

     public override void EnemyHit(float _damageDone)
    {
        base.EnemyHit(_damageDone);
    }
}
