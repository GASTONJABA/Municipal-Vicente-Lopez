using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{

    public List<Transform> posiblesMovimientos = new List<Transform>();
    public int currentPosicion = 0;
    public GameObject truck;





    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (posiblesMovimientos.Count > currentPosicion && currentPosicion >= 0)
        {
            truck.transform.position = posiblesMovimientos[currentPosicion].position;
        }

    }
}
