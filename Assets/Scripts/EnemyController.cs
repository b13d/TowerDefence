using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyController : MonoBehaviour
{
    public Image HealthBar;
    public List<GameObject> wayPoints = new List<GameObject>();
    private GameObject wayPointsGameObject;

    int indexPoint = 0;

    private Rigidbody2D enemyRb;
    public float fill = 1f;
    public int speed;
    Vector3 startPos;

    void Start()
    {
        StartSettings();
    }

    void StartSettings()
    {
        wayPointsGameObject = GameObject.Find("WayPoints");

        for (int i = 0; i < wayPointsGameObject.transform.childCount; i++)
        {
            wayPoints.Add(wayPointsGameObject.transform.GetChild(i).gameObject);
        }

        startPos = transform.position;
        enemyRb = GetComponent<Rigidbody2D>();
    }

    private void LateUpdate()
    {
        if (wayPoints.Count != indexPoint)
        {
            transform.position = Vector2.MoveTowards(transform.position, wayPoints[indexPoint].transform.position, Time.deltaTime * speed);

            if (transform.position == wayPoints[indexPoint].transform.position)
            {
                indexPoint++;
            }
        }
        else
        {
            transform.position = startPos;
            indexPoint = 0;
        }


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Zone"))
        {
            //Debug.Log(startPos);

            transform.position = startPos;
            //enemyRb.AddForce(Vector2.right * speed);
        }

        if (collision.gameObject.CompareTag("Arrow"))
        {
            HealthBar.fillAmount -= 0.5f;

            if (HealthBar.fillAmount == 0)
            {
                GameManager.coins += 50;
                gameObject.transform.parent.GetComponent<SpawnEnemy>().enemyList.Remove(gameObject);
                Destroy(gameObject);
            }
            collision.transform.parent.GetComponent<AttackEnemy>().arrows.Remove(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }


}
