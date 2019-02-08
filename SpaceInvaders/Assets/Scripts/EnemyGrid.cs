using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGrid : MonoBehaviour
{
    EnemyMovement enemyComponent;
    //Go into each child and set their direction to move to the opposite direction if an event is triggered.
    void Start()
    {
        enemyComponent = GameObject.Find("Enemy").GetComponent<EnemyMovement>();
        enemyComponent.hitWallEvent += OnHitWallEvent;
    }

    void OnHitWallEvent()
    {
        Debug.Log("Triggered!");
        bool enemyMR = this.transform.Find("Enemy").GetComponent<EnemyMovement>().moveRight;
        if (enemyMR)
            enemyMR = false;
        else
            enemyMR = true;
        //enemyMR = !enemyMR;
    }
}
