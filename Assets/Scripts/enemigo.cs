using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movimiento : MonoBehaviour
{

    public List<Transform> posiblesMovimientos = new List<Transform>();
    public int currentPosicion = 1;
    public GameObject truck;
    public float moveSpeed = 10f; // Velocidad para el movimiento suave (Lerp)




    // Start is called before the first frame update
    void Start()
    {
        // Asegurarse de que el cami�n empiece en la posici�n inicial
        if (posiblesMovimientos.Count > 0)
        {
            truck.transform.position = posiblesMovimientos[currentPosicion].position;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (posiblesMovimientos.Count > currentPosicion && currentPosicion >= 0)
        {

            Vector3 targetPosition = posiblesMovimientos[currentPosicion].position;
            // Mover gradualmente la posici�n hacia el objetivo
            truck.transform.position = Vector3.Lerp(truck.transform.position, targetPosition,
                Time.deltaTime * moveSpeed);
            //truck.transform.position = posiblesMovimientos[currentPosicion].position;
        }
    }
    // *** NUEVA FUNCI�N PARA EL INPUT SYSTEM ***
    // Esta funci�n debe coincidir con el nombre de la Action que creaste ("MoverCarril")
    // public void OnMoverCarril(InputAction.CallbackContext context)
    public void OnMoverCarril(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        // Solo reaccionamos cuando se presiona la tecla (context.performed)
        if (context.performed)
        {
            // Lee el valor del 1D Axis: +1 para positivo (derecha/siguiente), -1 para negativo (izquierda/anterior)
            float moveDirection = context.ReadValue<float>();

            // Calcula el nuevo �ndice, sumando o restando 1
            int newIndex = currentPosicion + (int)moveDirection;

            // Limita el �ndice para que no se salga de los l�mites de la lista (0 a Count - 1)
            currentPosicion = Mathf.Clamp(newIndex, 0, posiblesMovimientos.Count - 1);

            // Opcional: imprimir para depuraci�n
            Debug.Log("Cambiando a posici�n: " + currentPosicion);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si colisionamos con el objeto de Puntuaci�n
        if (other.CompareTag("Score"))
        {
            Debug.Log("�Puntuaci�n obtenida!");

            // **TODO: Implementar la l�gica del puntaje (ej: ScoreManager.AddScore(1));**

            // Destruir el objeto de puntuaci�n
            Destroy(other.gameObject);
        }
    }

    // **Manejo de Colisi�n (Objetos con Is Trigger = false, ej: Obst�culos)**
    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si colisionamos con el Obst�culo
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("�Colisi�n con Obst�culo! �Game Over!");
            Destroy(collision.gameObject);
            // **TODO: Implementar la l�gica de Game Over, reinicio, o p�rdida de vida.**

            // Ejemplo simple de Game Over: Congelar el tiempo
            Time.timeScale = 0f;
        }
    }








}


