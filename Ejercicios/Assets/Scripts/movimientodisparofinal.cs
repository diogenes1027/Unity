using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientodisparofinal : MonoBehaviour
{
    public float velocidad;
    public float fuego;
    public GameObject impacto;
    public GameObject golpe;


    // Start is called before the first frame update
    void Start()
    {
        if (impacto != null)
        {
            var impactoVfx = Instantiate(impacto,transform.position, Quaternion.identity);
            impactoVfx.transform.forward = gameObject.transform.forward;
            var parImpacto = impactoVfx.GetComponent<ParticleSystem>();

            if (parImpacto != null)
            {
                Destroy(impactoVfx, parImpacto.main.duration);

            }
            else
            {
                var parImpactoHija = impactoVfx.transform.GetChild(0).GetComponent<ParticleSystem>();
                Destroy(impactoVfx, parImpactoHija.main.duration);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (velocidad != 0) {
            transform.position += transform.forward * (velocidad * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        velocidad = 0;
        ContactPoint contacto = collision.contacts[0];
        Quaternion rotacion = Quaternion.FromToRotation(Vector3.up, contacto.normal);
        Vector3 posicion = contacto.point;

        if (golpe != null) {
            var golpeVfx = Instantiate(golpe,posicion,rotacion);
            var parGolpe = golpeVfx.GetComponent<ParticleSystem>();
            if (parGolpe != null)
            {
                Destroy(golpeVfx, parGolpe.main.duration);

            }
            else {
                var parGolpeHija = golpeVfx.transform.GetChild(0).GetComponent<ParticleSystem>();
                Destroy(golpeVfx, parGolpeHija.main.duration);

            }
        }

    }
}
