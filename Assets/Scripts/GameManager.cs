using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public float timer = 10;
    public float startTimer = 10;

    public Text playerVidas;
    public Slider recorrido;

    // Start is called before the first frame update
    void Start()
    {
        recorrido.maxValue = startTimer;
    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;
        recorrido.value = timer;
        if (timer < 0)

        {
            timer = startTimer;
            Debug.Log("Llegamos al Centro");
        }

        if (player.Vida <= 0)
        {
            Debug.Log("Game over");
        }

        playerVidas.text = "Vidas: " + player.Vida;

    }

}
