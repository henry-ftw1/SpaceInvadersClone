using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyGrid : MonoBehaviour
{
    EnemyMovement enemyComponent;
    EnemyMovement enemyDeath;

    public bool moveR;
    private int rowCount;
    public float gridSpeed;
    public float gridDown;
    public float shootPercent;
    public int score = 0;
    public Text scoretext;

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
        scoretext.text = "Score: " + score.ToString();
        for (int i = 0; i < rowCount; i++)
        {
            Transform rowI = this.gameObject.transform.GetChild(i);
            for (int x = 0; x < this.gameObject.transform.GetChild(i).childCount; x++)
            {
                enemyComponent = rowI.GetChild(x).GetComponent<EnemyMovement>();
                enemyComponent.HitWallEvent += OnHitWallEvent;

                enemyDeath = rowI.GetChild(x).GetComponent<EnemyMovement>();
                enemyDeath.DeathEvent += OnDeathEvent;

                enemyList.Add(rowI.GetChild(x).transform);
            }
        }
    }

    private void Update()
    {
        randomShoot();
        if (score == 1100)
        {
            SceneManager.LoadScene("Win");
        }
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
        int eCount = enemyList.Count;
        for (int i = 0; i < eCount; i++)
        {
            if (enemyList[i] != null)
            {
                if (enemyList[i].name == name)
                {
                    score += enemyList[i].GetComponent<EnemyMovement>().points;
                    scoretext.text = "Score: " + score.ToString();
                    Destroy(enemyList[i].gameObject);
                    enemyList[i] = null;
                }
            }
        }
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
                if (enemyList[indexNumber] != null)
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
