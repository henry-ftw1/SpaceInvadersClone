using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile1 : MonoBehaviour
{
    public int speed = 5;
    private Rigidbody2D playerprojectile_rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        playerprojectile_rigidbody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        playerprojectile_rigidbody.velocity = new Vector2(0, speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
