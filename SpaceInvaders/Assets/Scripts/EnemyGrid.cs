using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGrid : MonoBehaviour
{
    //EnemyMovement enemyComponent;
    ////Go into each child and set their direction to move to the opposite direction if an event is triggered.
    //void Start()
    //{
    //    enemyComponent = GameObject.Find("Enemy").GetComponent<EnemyMovement>();
    //    enemyComponent.hitWallEvent += OnHitWallEvent;
    //}

    //void OnHitWallEvent()
    //{
    //    int childCount = this.transform.childCount;
    //    for (int i = 1; i <= childCount; i++)
    //    {
    //        if (i == 1)
    //            this.transform.Find("Enemy").GetComponent<EnemyMovement>().moveRight = !this.transform.Find("Enemy").GetComponent<EnemyMovement>().moveRight;
    //        else
    //        {
    //            string ECount = string.Format("Enemy ({0})", i);
    //            Debug.LogFormat("Triggered! {0}", ECount);
    //            this.transform.Find(ECount).GetComponent<EnemyMovement>().moveRight = !this.transform.Find(ECount).GetComponent<EnemyMovement>().moveRight;
    //        }
    //    }
    //    //Debug.Log("Triggered!");
    //    //this.transform.Find("Enemy").GetComponent<EnemyMovement>().moveRight = !this.transform.Find("Enemy").GetComponent<EnemyMovement>().moveRight;
    //}
}
