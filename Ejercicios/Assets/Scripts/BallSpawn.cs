using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public int ballmass = 2;
    public float bounciness = 1.0f;

    void Start()
    {
        float cR = Random.Range(0.0f, 1.0f);
        float cG = Random.Range(0.0f, 1.0f);
        float cB = Random.Range(0.0f, 1.0f);
        Color c = new Color(cR, cG, cB);
        createSphere(c);
    }

    GameObject createSphere(Color color)
    {

        GameObject mySphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        mySphere.transform.localPosition = gameObject.transform.position;

        Renderer rend = mySphere.GetComponent<Renderer>();
        rend.material = new Material(Shader.Find("Standard"));
        rend.material.SetColor("_Color", color);


        Rigidbody rb = mySphere.AddComponent<Rigidbody>();
        rb.mass = ballmass;

        PhysicMaterial mat = new PhysicMaterial();
        mat.bounciness = bounciness;
        Collider collider = mySphere.GetComponent<Collider>();
        collider.material = mat;

        return mySphere;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
