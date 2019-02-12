using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyMovement : MonoBehaviour
{
    private float moveSpeed;
    private float moveDown;
    public int points;
    string m_Name;

    public GameObject enemy_projectile;

    public delegate void hitWallDelegate();
    public event hitWallDelegate HitWallEvent = delegate { };

    public delegate void deathDelegate(string n);
    public event deathDelegate deathEvent = delegate{ };


    // Start is called before the first frame update
    private void Awake()
    {
        points = 10;
        m_Name = this.transform.name;
    }
    void Start()
    {
        moveSpeed = this.transform.parent.GetComponentInParent<EnemyGrid>().gridSpeed;
        moveDown = this.transform.parent.GetComponentInParent<EnemyGrid>().gridDown;

        //m_rb.velocity = new Vector2(moveSpeed, 0);
        //this.transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
    }

    //Update is called once per frame
    void Update()
    {
        Move();
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

    public void Shoot()
    {
        Vector2 here = (Vector2)this.transform.position;
        Instantiate(enemy_projectile, here, Quaternion.identity);
        //Debug.LogFormat("Name: {0}", m_Name);
    }

    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    //if (other.collider.CompareTag("Wall"))
    //    //    hitWallEvent();
    //}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerProjectile"))
        {
            //deathEvent(m_Name);
            Destroy(gameObject);
        }
        if (other.CompareTag("Wall"))
            HitWallEvent();
    }
}
