using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    public GameObject arrow;
    public List<GameObject> arrows;
    public int speedArrow = 10;
    public float distance = 1f;
    private float timeleft = 1;
    private Transform enemyTransformTarget;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {
        timeleft -= Time.deltaTime;
    }

    private void Update()
    {
        MoveArrow();
    }

    void MoveArrow()
    {
        if (enemyTransformTarget != null)
        {
            for (int i = 0; i < arrows.Count; i++)
            {
                Vector3 vectorToTarget = enemyTransformTarget.position - arrows[i].transform.position;
                float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
                Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
                var rotationArrow = Quaternion.Slerp(arrows[i].transform.rotation, q, Time.deltaTime * speedArrow);

                arrows[i].transform.position = Vector2.MoveTowards(arrows[i].transform.position, enemyTransformTarget.position, Time.deltaTime * 3f);
                arrows[i].transform.rotation = rotationArrow;
            }

        }
    }

    /*    private void OnTriggerEnter2D(Collider2D collision)
        {
            bool onPlace = transform.parent.GetComponent<SelectTower>().OnPlace;

            if (collision.CompareTag("Enemy") && onPlace)
            {

                arrows.Add(Instantiate(arrow, transform.position, arrow.transform.rotation, transform));
                enemyTransformTarget = collision.transform;

                //arrows[arrows.Count - 1].GetComponent<Rigidbody2D>().AddForce((collision.transform.position - transform.position).normalized * speedArrow);

                StartCoroutine("WaitAndDestroyArrow", arrows[arrows.Count - 1].gameObject);
            }
        }*/

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (timeleft < 0)
        {
            timeleft = 1;

            bool onPlace = transform.parent.GetComponent<SelectTower>().OnPlace;

            if (collision.CompareTag("Enemy") && onPlace)
            {

                arrows.Add(Instantiate(arrow, transform.position, arrow.transform.rotation, transform));
                enemyTransformTarget = collision.transform;

                //arrows[arrows.Count - 1].GetComponent<Rigidbody2D>().AddForce((collision.transform.position - transform.position).normalized * speedArrow);

                StartCoroutine("WaitAndDestroyArrow", arrows[arrows.Count - 1].gameObject);
            }
        }


    }

    private IEnumerator WaitAndDestroyArrow(GameObject arrow)
    {
        yield return new WaitForSeconds(3);

        if (arrow != null)
        {
            enemyTransformTarget = null;
            arrows.Remove(arrow);
            Destroy(arrow);
        }

    }
}
