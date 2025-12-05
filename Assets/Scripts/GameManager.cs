using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{   
    public Player player;
   // public playerSound playerSound;
    public float tiemmpoMaximo = 60;//antes timer
    public float tiempoActual = 50;//antes starttimer
    public Slider recorrido; //esta sera la referencia del slider gastontontorontonton
  

    public Text playerVidas;
    public Text playerPuntaje;

    public GameObject canvasVictoria;
    public GameObject canvasPerdiste;
    public bool juegoTerminado = false;

    // Start is called before the first frame update
    void Start()
    {
        //playerSound.playSoundFondo();
        recorrido.maxValue = tiemmpoMaximo;
        // 2. Establece el valor ACTUAL del slider a 0 para que inicie vacío
        recorrido.value = tiempoActual;
    }

    // Update is called once per frame
    //La función Update() debe hacer que el tiempoActual avance y se compare con el tiempoMaximo(60).   
    void Update()
    {

        //timer -= Time.deltaTime;
        // recorrido.value = timer;
        if (tiempoActual < tiemmpoMaximo)

        {// 2. Aumenta el tiempo.
            tiempoActual += Time.deltaTime;

            // 3. ¡ACTUALIZA el Slider!
            recorrido.value = tiempoActual;
            // timer = startTimer;
            // Debug.Log("Llegamos al Centro");
            // Activa la pantalla de victoria
            //canvasVictoria.SetActive(true);
        }
        else
           
        if (canvasVictoria.activeSelf ==false)
        {
            Debug.Log("you win");
            canvasVictoria.SetActive(true);
            // Congela el tiempo
            Time.timeScale = 1f;

            playerPuntaje.text = "Puntaje: " + player.Score;

            // Opcional: Desactiva el script para que no se ejecute más
            this.enabled = false;
        }

        if (juegoTerminado == false && player.Vida <= 0)//(player.Vida <= 0)
        {
            Debug.Log("Game over");
            juegoTerminado = true;
           
            canvasPerdiste.SetActive(true);
            //playerSound.stopSoundFondo();

            // Congela el tiempo
            Time.timeScale = 1f;
            // Opcional: Desactiva el script para que no se ejecute más
            //this.enabled = false;
        }

        playerVidas.text = "Vidas: " + player.Vida;

        playerPuntaje.text = "Puntaje: " + player.Score;

    }

   

}
