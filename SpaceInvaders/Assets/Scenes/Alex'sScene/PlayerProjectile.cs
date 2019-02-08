using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
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

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
