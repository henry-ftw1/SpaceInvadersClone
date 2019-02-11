using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGrid : MonoBehaviour
{
    EnemyMovement enemyComponent;
    public bool moveR;

    private void Awake()
    {
        moveR = true;
    }

    //Go into each child and set their direction to move to the opposite direction if an event is triggered.
    void Start()
    {
        int rowCount = this.gameObject.transform.childCount;
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

    void OnHitWallEvent()
    {
        //Debug.Log("Event Was Hit");
        moveR = !moveR;
        int childCount = this.gameObject.transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            
        }
        int rowCount = this.gameObject.transform.childCount;
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
}
