using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTarget : MonoBehaviour
{

    public GameObject bullet;
    public List<GameObject> bullets;
    public int speedBullet = 2;
    public int intervalBulletSecond = 300;
    public int counter = 0;
    bool isPlaying = true;
    bool isReady = false;
    public Vector3 enemyTransform;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && isPlaying && PlayerEditing.onMousePlace)
        {
            StartCoroutine(LastPositionEnemy(collision.transform));


            if (enemyTransform != null)
                StartCoroutine(WaitBullet());
        }

        /*        if (collision.CompareTag("Enemy") && isPlaying && PlayerEditing.onMousePlace)
                {
                    enemyTransform = collision.transform;
                    BulletToEnemy();
                    //StartCoroutine(WaitBullet(collision.transform));
                    //BulletToEnemy(collision.transform);
                }*/

    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            StopCoroutine(WaitBullet());
            StopCoroutine(LastPositionEnemy(collision.transform));

        }
    }

    void BulletToEnemy()
    {
        bullets.Add(Instantiate(bullet, transform.position, bullet.transform.rotation));

        bullets[bullets.Count - 1].GetComponent<Rigidbody2D>().AddForce(enemyTransform.normalized * speedBullet, ForceMode2D.Impulse);

        if (bullets.Count > 10)
        {
            for (int i = 0; i < bullets.Count - 5; i++)
            {
                Destroy(bullets[i]);
                bullets.Remove(bullets[i]);
            }
        }

    }

    IEnumerator WaitBullet()
    {
        yield return new WaitForSeconds(1);
        BulletToEnemy();
    }

    IEnumerator LastPositionEnemy(Transform lastPosEnemy)
    {
        yield return new WaitForSeconds(0);

        if (lastPosEnemy != null)
        {
            enemyTransform = lastPosEnemy.position;
        }
    }
}
