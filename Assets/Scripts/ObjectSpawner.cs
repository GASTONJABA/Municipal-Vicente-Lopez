using UnityEngine;
using System.Collections.Generic;

public class ObjectSpawner : MonoBehaviour
{


    // Las mismas posiciones que usa el Bus
    public List<Transform> lanePositions = new List<Transform>();

    [Header("Prefabs")]
    public GameObject obstaclePrefab; // Tu modelo de Obst�culo
    public GameObject scoreItemPrefab; // Tu modelo de Puntuaci�n

    [Header("Configuraci�n de Spawn")]
    public float spawnRate = 1.5f; // Frecuencia de aparici�n (cada 1.5 segundos)
    public float obstacleChance = 0.7f; // 70% de probabilidad de ser Obst�culo
    public float initialDelay = 2f; // Retraso antes de que empiece a generar

    void Start()
    {
        // Esto llama a 'SpawnObject' cada 'spawnRate' segundos, empezando despu�s de 'initialDelay' segundos.
        InvokeRepeating("SpawnObject", initialDelay, spawnRate);
    }

    void SpawnObject()
    {
        if (lanePositions.Count == 0)
        {
            Debug.LogError("El Spawner necesita las referencias a las posiciones de carril.");
            return;
        }

        // 1. Decidir qu� carril usar (aleatorio entre 0, 1, 2)
        int randomLaneIndex = Random.Range(0, lanePositions.Count);
        Vector3 spawnPoint = lanePositions[randomLaneIndex].position;

        // 2. Decidir qu� tipo de objeto generar
        GameObject prefabToInstantiate;

        if (Random.value < obstacleChance) // Random.value es un float entre 0.0 y 1.0
        {
            prefabToInstantiate = obstaclePrefab;
        }
        else
        {
            prefabToInstantiate = scoreItemPrefab;
        }

        // 3. Crear el objeto en la escena
        Instantiate(prefabToInstantiate, spawnPoint, Quaternion.identity);

    }





    private void OnTriggerEnter(Collider other)
    {
        // Verifica si colisionamos con el objeto de Puntuaci�n
        if (other.CompareTag("Muro"))
        {
            Debug.Log("�pluum!");

            // **TODO: Implementar la l�gica del puntaje (ej: ScoreManager.AddScore(1));**

            // Destruir el objeto de puntuaci�n
            Destroy(other.gameObject);
        }





    }
}