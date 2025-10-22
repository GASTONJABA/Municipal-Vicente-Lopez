using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector2 Velocidad;
    public Vector2 offset;
    private Material material;


    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;

    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        offset = Velocidad * Time.deltaTime;
        material.mainTextureOffset += offset;


    }
}
