using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coins : MonoBehaviour
{
    public GameObject coins;
    public GameObject wave;
    private TextMeshProUGUI coinsText;
    private TextMeshProUGUI waveText;


    void Start()
    {
        coinsText = coins.GetComponent<TextMeshProUGUI>();
        waveText = wave.GetComponent<TextMeshProUGUI>();

        waveText.text = "Волна " + GameManager.wave.ToString() + " / 10";
        coinsText.text = GameManager.coins.ToString();
    }

    private void Update()
    {
        if (GameManager.coins.ToString() != coinsText.text)
        {
            coinsText.text = GameManager.coins.ToString();
        }

        if (GameManager.wave.ToString() != waveText.text)
        {
            waveText.text = "Волна " + GameManager.wave.ToString() + " / 10";
        }
    }

}
