using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ProjectTile : MonoBehaviour
{
    public int damage = 10;
    public Vector2 moveSpeed = new Vector2(4f,0);
    public Vector2 knockBack = new Vector2(0, 0);
    public double hasExitTimer = 5;
    Rigidbody2D rb;

    void Start()
    {
        rb.velocity = new Vector2(moveSpeed.x * transform.localScale.x, moveSpeed.y);


    }

    private void  Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    Timer y;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageAble damageAble = collision.GetComponent<DamageAble>();

        if (damageAble != null)
        {
            Vector2 deliveredKnockback = transform.localScale.x > 0 ? knockBack : new Vector2(-knockBack.x, knockBack.y);
            bool getHit = damageAble.Hit(damage, deliveredKnockback);
            if (getHit)
            {

                Debug.Log(collision.name + "get" + damage);
                Destroy(gameObject);
            }

        }
    }
}
