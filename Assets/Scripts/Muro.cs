using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muro : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si colisionamos con el objeto de Puntuaci�n
        if (other.CompareTag("Score"))
        {
            Debug.Log("walll!");

            // **TODO: Implementar la l�gica del puntaje (ej: ScoreManager.AddScore(1));**

            // Destruir el objeto de puntuaci�n
            Destroy(other.gameObject);
        }

        // Verifica si colisionamos con el Obst�culo
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("waaalll");
            Destroy(other.gameObject);
            // **TODO: Implementar la l�gica de Game Over, reinicio, o p�rdida de vida.**

            // Ejemplo simple de Game Over: Congelar el tiempo
            //Time.timeScale = 0f;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
