using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public GameObject puntoDisparo;
    public List<GameObject> vfx = new List<GameObject>();
    private GameObject efecto;
    public float tiempoDisparo=0;
    public bool banderaDisparo = false;
    // Start is called before the first frame update
    void Start()
    {
        efecto = vfx[0];
    }

    // Update is called once per frame
    void Update()
    {
        banderaDisparo = false;
        if (Input.GetKey(KeyCode.Space) && Time.time >= tiempoDisparo)
        {
            tiempoDisparo = Time.time + 1 / efecto.GetComponent<movimientodisparofinal>().fuego;
            banderaDisparo = true;
            mostrarvfx();
        }

    }

    void mostrarvfx() {

        GameObject localVfx;

        if (puntoDisparo != null)
        {
            localVfx = Instantiate(efecto, puntoDisparo.transform.position, Quaternion.identity);

        }
    }
}
