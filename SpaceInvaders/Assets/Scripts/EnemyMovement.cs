using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed;
    private float moveDown;
    private bool moveRight;

    public Rigidbody2D m_rb;
    EnemyMovement enemyComponent;

    public delegate void hitWallDelegate();
    public event hitWallDelegate hitWallEvent = delegate { };


    // Start is called before the first frame update
    private void Awake()
    {
        moveSpeed = 10f;
        moveDown = 0.1f;
        moveRight = true;
        m_rb = this.transform.GetComponent<Rigidbody2D>();
        enemyComponent = GameObject.Find("Enemy").GetComponent<EnemyMovement>();
        enemyComponent.hitWallEvent += OnHitWallEvent;
    }
    void Start()
    {
    }

    // Update is called once per frame
    //void Update()
    //{
    //    Move();
    //}

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if(moveRight)
        {
            //m_rb.AddForce(Vector2.right);
            this.transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
        }
            
        else
        {
            //m_rb.AddForce(Vector2.left);
            this.transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
        }
    }



    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Wall"))
        {
            this.transform.Translate(Vector2.down * moveDown);
            hitWallEvent();
            //Debug.Log("Hit Collider");
            //moveRight = !moveRight;
        }
    }

    void OnHitWallEvent()
    {
        Debug.Log("Hit Wall Event Triggered");
        this.moveRight = !this.moveRight;
    }
}
