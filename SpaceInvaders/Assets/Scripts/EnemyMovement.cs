using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed;
    private bool moveRight;

    // Start is called before the first frame update
    private void Awake()
    {
        moveSpeed = 0.5f;
        moveRight = true;
    }
    void Start()
    {
        //Move();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (moveRight)
            this.transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        else
            this.transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Wall"))
        {
            Debug.Log("Hit Collider");
            moveRight = !moveRight;
            //Move();
        }
    }
}
