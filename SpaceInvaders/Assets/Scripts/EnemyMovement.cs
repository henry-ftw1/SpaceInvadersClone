using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed;
    private float moveDown;
    private bool moveRight;

    public GameObject enemy_projectile;
    public Rigidbody2D m_rb;
    private Vector2 m_position;
    EnemyMovement enemyComponent;

    public delegate void hitWallDelegate();
    public event hitWallDelegate hitWallEvent = delegate { };


    // Start is called before the first frame update
    private void Awake()
    {
        moveSpeed = 5f;
        moveDown = 0.1f;
        moveRight = true;
        m_rb = this.transform.GetComponent<Rigidbody2D>();
        m_position = (Vector2)this.transform.position;
        enemyComponent = GameObject.Find("Enemy").GetComponent<EnemyMovement>();
        enemyComponent.hitWallEvent += OnHitWallEvent;
    }
    void Start()
    {
        m_rb.velocity = new Vector2(moveSpeed, 0);
    }

    //Update is called once per frame
    void Update()
    {
        Move();

        if (!(GameObject.Find("EnemyProjectile(Clone)")))
        {
            shoot();
        }
    }

    void Move()
    {
        if(moveRight)
        {
            ////m_rb.AddForce(Vector2.right);
            //this.transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
            m_position = new Vector2(m_position.x + 1, 0);
        }
        else
        {
            ////m_rb.AddForce(Vector2.left);
            //this.transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
            m_position = new Vector2(m_position.x - 1, 0);
        }
    }

    void shoot()
    {
        Vector2 here = (Vector2)this.transform.position;
        Instantiate(enemy_projectile, here, Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Wall"))
        {
            this.transform.Translate(Vector2.down * moveDown);
            OnHitWallEvent();
            //Debug.Log("Hit Collider");
            //moveRight = !moveRight;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerProjectile"))
        {
            Destroy(gameObject);
        }
    }


    void OnHitWallEvent()
    {
        Debug.Log("Hit Wall Event Triggered");
        moveRight = !moveRight;
        moveSpeed = -moveSpeed;
        m_rb.velocity = new Vector2(moveSpeed, 0);
        this.transform.Translate(Vector2.down * moveDown);
    }
}
