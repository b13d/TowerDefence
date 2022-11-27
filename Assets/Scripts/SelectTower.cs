using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTower : MonoBehaviour
{

    public bool OnPlace
    {
        get { return onPlace; }
    }

    public SelectPlace scriptPlace;
    public Canvas messageAboutTower;
    public GameObject triggerAttack;
    public int priceTower;

    Vector3 initialTransform;
    Vector3 sizeTowerOnSelected = new Vector3(.4f, .4f, .4f);
    bool onPlace = false;

    void Start()
    {
        PriceTower();

        initialTransform = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void PriceTower()
    {
        if (gameObject.name == "Tower")
        {
            priceTower = 100;
        }
        else if (gameObject.name == "Tower 1")
        {
            priceTower = 50;
        }
        else
        {
            priceTower = 200;
        }

        if (transform.localScale.x > 0.58f)
        {
            onPlace = true;
        }
    }

    private void OnMouseEnter()
    {
        if (onPlace == false)
        {
            messageAboutTower.gameObject.SetActive(true);

            Debug.Log("Навелись на башню: " + gameObject.name);
            //transform.localScale = sizeTowerOnSelected;

            transform.localScale = Vector3.Lerp(sizeTowerOnSelected, initialTransform, Time.fixedDeltaTime);
        }

    }

    private void OnMouseExit()
    {
        if (onPlace == false)
        {
            messageAboutTower.gameObject.SetActive(false);

            Debug.Log("Убрал мышку: " + gameObject.name);

            //transform.localScale = initialTransform;
            transform.localScale = Vector3.Lerp(initialTransform, sizeTowerOnSelected, Time.fixedDeltaTime);
        }
 
    }

    private void OnMouseDown()
    {
        if (onPlace == false && GameManager.coins >= priceTower)
        {
            GameManager.coins -= priceTower;

            triggerAttack.SetActive(true);
            messageAboutTower.gameObject.SetActive(false);
            onPlace = true;
            scriptPlace.enabled = false;
            transform.localScale = new Vector3(.60f, .60f, .60f);
            Instantiate(gameObject, transform.parent.transform.parent.position + new Vector3(0, 0.4f, 0), gameObject.transform.rotation, transform.parent.parent.transform);
            transform.parent.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Ты БОМЖ, ТЫ ДАЖЕ НЕ ГРАЖДАНИН!");
        }

    }


}
