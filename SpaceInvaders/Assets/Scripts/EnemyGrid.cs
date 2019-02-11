using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGrid : MonoBehaviour
{
    EnemyMovement enemyComponent;
    public bool moveR;
    private int rowCount;
    public float gridSpeed;
    public float gridDown;

    private void Awake()
    {
        moveR = true;
        rowCount = this.gameObject.transform.childCount;
        gridSpeed = 5f;
        gridDown = 0.1f;
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
                enemyComponent.hitWallEvent += OnHitWallEvent;
            }
        }
    }

    private void LateUpdate()
    {
        //randomShot();
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

    //void randomShot()
    //{
    //    float shouldShoot = Random.value;
    //    if(shouldShoot >= 0.99)
    //    {
    //        int shootingColumn = Random.Range(1, 12);

    //        for (int i = 0; i < rowCount; i++)
    //        {
    //            Transform rowI = this.gameObject.transform.GetChild(i);
    //            //if rowI(@shootingColumn) has an enemy, make it shoot or else move onto the next row
    //            //if row is empty then choose another shooting column
    //        }

    //    }
    //}
}
