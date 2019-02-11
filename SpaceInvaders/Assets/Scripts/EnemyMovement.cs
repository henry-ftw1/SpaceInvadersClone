using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed;
    private float moveDown;
    public int points;

    public GameObject enemy_projectile;

    public delegate void hitWallDelegate();
    public event hitWallDelegate hitWallEvent = delegate { };


    // Start is called before the first frame update
    private void Awake()
    {
        moveSpeed = 5f;
        moveDown = 0.1f;
        points = 10;
    }
    void Start()
    {
        //m_rb.velocity = new Vector2(moveSpeed, 0);
        //this.transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
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

    public void Move()
    {
        if(this.transform.parent.GetComponentInParent<EnemyGrid>().moveR)
        {
            this.transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
        }
        else
        {
            this.transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
        }
    }

    public void MoveDown()
    {
        this.transform.Translate(Vector2.down * moveDown);
    }

    void shoot()
    {
        Vector2 here = (Vector2)this.transform.position;
        Instantiate(enemy_projectile, here, Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Wall"))
            hitWallEvent();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerProjectile"))
        {
            Destroy(gameObject);
        }
    }
}
