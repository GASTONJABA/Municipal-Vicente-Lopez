using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    // 1. Variable p�blica para controlar la velocidad desde el Inspector de Unity
    [SerializeField]
    private float velocidad = 5.0f;
   
    // Este m�todo se llama una vez por cada frame.
    void Update()
    {
        // 2. Define la direcci�n del movimiento (X negativo)
        Vector3 direccionDeMovimiento = Vector3.left; // Es lo mismo que new Vector3(-1, 0, 0)

        // 3. Calcula el desplazamiento
        // Multiplicamos la direcci�n por la velocidad y por Time.deltaTime
        // Time.deltaTime asegura que el movimiento sea suave e independiente de la tasa de frames.
        Vector3 desplazamiento = direccionDeMovimiento * velocidad * Time.deltaTime;

        // 4. Aplica el desplazamiento a la posici�n actual del objeto
        // transform.Translate mueve el objeto en el espacio local.
        transform.Translate(desplazamiento);





    }
}