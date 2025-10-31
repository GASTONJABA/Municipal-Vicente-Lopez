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
        // Verifica si colisionamos con el objeto de Puntuación
        if (other.CompareTag("Score"))
        {
            Debug.Log("walll!");

            // **TODO: Implementar la lógica del puntaje (ej: ScoreManager.AddScore(1));**

            // Destruir el objeto de puntuación
            Destroy(other.gameObject);
        }

        // Verifica si colisionamos con el Obstáculo
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("waaalll");
            Destroy(other.gameObject);
            // **TODO: Implementar la lógica de Game Over, reinicio, o pérdida de vida.**

            // Ejemplo simple de Game Over: Congelar el tiempo
            //Time.timeScale = 0f;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
