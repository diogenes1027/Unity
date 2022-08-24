using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : MonoBehaviour
{
    public float wait;
    bool exploted = false;
    public float radius = 6f;
    public float force = 500f;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        wait = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        wait -= Time.deltaTime;
        if (wait <= 0f && !exploted) {
            exploted = true;
            explote();
        }
    }

    void explote() {
        Instantiate(explosion, transform.position, transform.rotation);

        Collider[] col = Physics.OverlapSphere(transform.position,radius);

        foreach (Collider cercano in col) {
            Rigidbody rb = cercano.GetComponent<Rigidbody>();

            if (rb != null) {
                rb.AddExplosionForce(force,transform.position,radius);
            }
        }

        Destroy(gameObject);
        Destroy(GameObject.Find("BigExplosion(Clone)"), 2f);
       
    }
}
