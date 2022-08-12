using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    float x;
    float y;
    float z;

    public float speed = 20;

    void mirotacion()
    {
        x += 20 * Time.deltaTime;
        y += speed * Time.deltaTime;
        z += 20 * Time.deltaTime;

        gameObject.transform.localRotation = Quaternion.Euler(0, -y, 0);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mirotacion();
    }
}
