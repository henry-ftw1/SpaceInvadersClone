﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player1 : MonoBehaviour
{
    // Start is called before the first frame update
    public int lives = 3;
    public int speed = 3;
    public Text livetext;
    public GameObject player_projectile;
    private Rigidbody2D player_rigidbody;

    void Start()
    {
        player_rigidbody = this.GetComponent<Rigidbody2D>();
        livetext.text = "Lives: " + lives.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        move();

        if ((Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space)) && !(GameObject.Find("PlayerProjectile(Clone)")))
        {
            shoot();
        }
        if (lives <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Over");
        }
    }

    void move()
    {
        float moveModifier = Input.GetAxis("Horizontal");
        Vector2 currentVelocity = player_rigidbody.velocity;
        player_rigidbody.velocity = new Vector2(moveModifier * speed, currentVelocity.y);
    }

    void shoot()
    {
        Vector2 here = (Vector2)this.transform.position;
        Instantiate(player_projectile, here, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyProjectile"))
        {
            --lives;
            livetext.text = "Lives: " + lives.ToString();
        }
    }
}
