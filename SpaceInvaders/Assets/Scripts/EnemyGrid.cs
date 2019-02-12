﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGrid : MonoBehaviour
{
    EnemyMovement enemyComponent;
    EnemyMovement enemyDeath;

    public bool moveR;
    private int rowCount;
    public float gridSpeed;
    public float gridDown;
    public float shootPercent;
    
    List<Transform> enemyList;

    private void Awake()
    {
        moveR = true;
        rowCount = this.gameObject.transform.childCount;
        gridSpeed = 2f;
        gridDown = 0.05f;
        shootPercent = 0.02f;
        enemyList = new List<Transform>();
    }

    //Go into each child and set their direction to move to the opposite direction if an event is triggered.
    void Start()
    {
        for (int i = 0; i < rowCount; i++)
        {
            Transform rowI = this.gameObject.transform.GetChild(i);
            for (int x = 0; x < this.gameObject.transform.GetChild(i).childCount; x++)
            {
                enemyComponent = rowI.GetChild(x).GetComponent<EnemyMovement>();
                enemyComponent.HitWallEvent += OnHitWallEvent;

                enemyDeath = rowI.GetChild(x).GetComponent<EnemyMovement>();
                enemyDeath.deathEvent += OnDeathEvent;
                enemyList.Add(rowI.GetChild(x).transform);
            }
        }
    }

    private void LateUpdate()
    {
        //if (!GameObject.Find("EnemyProjectile(Clone)"))
        //{
        //    randomShoot();
        //}
        randomShoot();
    }

    void OnHitWallEvent()
    {
        //Debug.Log("Event Was Hit");
        moveR = !moveR;
        for (int i = 0; i < rowCount; i++)
        {
            Transform rowI = this.gameObject.transform.GetChild(i);
            for (int x = 0; x < this.gameObject.transform.GetChild(i).childCount; x++)
            {
                
                EnemyMovement enemy = rowI.GetChild(x).GetComponent<EnemyMovement>();
                enemy.MoveDown();
                enemy.Move();
            }
        }
    }

    void OnDeathEvent(string name)
    {
        //Transform deadEnemy = this.transform.Find(name);
        //if (enemyList.Contains(deadEnemy))
        //{
        //    int index = enemyList.FindIndex();
        //    Destroy(enemyList[index].gameObject);
        //}

    }

    void randomShoot()
    {
        float shouldShoot = Random.value;
        if (shouldShoot <= shootPercent)
        {
            int shootingColumn = Random.Range(0, 11);
            for (int i = 0; i < rowCount; i++)
            {
                int indexNumber = (i * 11) + shootingColumn;
                if(enemyList[indexNumber] != null)
                {
                    //if(indexNumber == 0)
                    //{
                    //    Debug.LogFormat("Enemy #{0} shot", indexNumber);
                    //    Destroy(enemyList[indexNumber].gameObject);
                    //}
                    enemyList[indexNumber].GetComponent<EnemyMovement>().Shoot();
                    return;
                }
            }
        }
    }
}
