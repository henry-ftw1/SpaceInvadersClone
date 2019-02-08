using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed;
    public float moveDown;
    public bool moveRight;

    public delegate void hitWallDelegate();
    public event hitWallDelegate hitWallEvent = delegate { };


    // Start is called before the first frame update
    private void Awake()
    {
        moveSpeed = 10f;
        moveDown = 0.1f;
        moveRight = true;
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (moveRight)
        {
            this.transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
        }
            
        else
        {
            this.transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
        }
    }



    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Wall"))
        {
            //this.transform.Translate(Vector2.down * moveDown);
            hitWallEvent();
            //Debug.Log("Hit Collider");
            //moveRight = !moveRight;
        }
    }
}
