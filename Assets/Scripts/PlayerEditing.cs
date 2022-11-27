using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEditing : MonoBehaviour
{

    public static bool onMousePlace = false;
    public bool onPlace = false;
    Vector2 placePos;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("mouseX: " + Input.mousePosition.x + " mouseY: " + Input.mousePosition.y + " mouseZ: " + Input.mousePosition.z);

    }




    private void OnMouseDrag()
    {
        if (onPlace == false)
        {
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }



    private void OnMouseUp()
    {
        if (onMousePlace && !onPlace)
        {
            onPlace = true;
            transform.position = placePos;
        }


    }



    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Place") && !onPlace)
        {

            placePos = collision.transform.position;
            Debug.Log("Позиция места: " + placePos);

            onMousePlace = true;
        }
    }



    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Place") && !onPlace)
        {


            placePos = Vector2.zero;
            onMousePlace = false;
        }
    }

}
