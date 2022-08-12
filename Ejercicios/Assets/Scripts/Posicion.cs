using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Posicion : MonoBehaviour
{
    private Vector3 cambio;
    bool bandera = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        posicionFig();
    }

    void posicionFig()
    {


        if (gameObject.transform.localPosition.x < 0)
        {
            bandera = false;
        }
        if (gameObject.transform.localPosition.x > 3)
        {
            bandera = true;
        }
        if (bandera)
        {
            cambio = new Vector3(-0.01f, -0.01f, -0.01f);
        }
        else
        {
            cambio = new Vector3(0.01f, 0.01f, 0.01f);
        }

        gameObject.transform.localPosition += cambio;

        
    }
}