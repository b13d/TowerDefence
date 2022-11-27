using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlace : MonoBehaviour
{
    //color 9D9D9D when hover

    public bool mouseEntered = false;

    private SpriteRenderer spritePlace;
    public GameObject menuTowers;
    public List<GameObject> selectedTowers = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        spritePlace = GetComponent<SpriteRenderer>();
    }



    void OnMouseEnter()
    {
        if (transform.childCount == 1)
        {
            mouseEntered = true;
            spritePlace.color = new Color(0.613f, 0.613f, 0.613f);
        }

    }

    private void OnMouseExit()
    {
        if (transform.childCount == 1)
        {
            mouseEntered = false;
            spritePlace.color = new Color(1f, 1f, 1f);
        }

    }

    private void OnMouseDown()
    {
        if (transform.childCount == 1)
        {
            if (mouseEntered && !menuTowers.activeSelf)
            {
                menuTowers.SetActive(true);
            }
            else if (mouseEntered && menuTowers.activeSelf)
            {
                menuTowers.SetActive(false);
            }
        }

    }
}
