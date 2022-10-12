using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Illumination : MonoBehaviour
{
    Vector3 ka = new Vector3(0.12f, 0.12f, 0.12f);
    Vector3 kd = new Vector3(1f, 1f, 0f);
    Vector3 ks = new Vector3(0.8f, 0.8f, 0f);
    Vector3 Ia = new Vector3(1f, 1f, 1f);
    Vector3 Id = new Vector3(1f, 1f, 1f);
    Vector3 Is = new Vector3(1f, 1f, 1f);

    public Vector3 LIGHT = new Vector3(8.7f, 3.2f, -1.1f);
    public Vector3 PoI = new Vector3(0.5f, 0.55f, 0.79f);
    public Vector3 CAMERA = new Vector3(-3.6f, 4.03f, 2.5f);
    public Vector3 SC = new Vector3(0.5f, -0.7f, 0.79f);
    Vector3 n;

    public int alpha = 75;
    public float SR = 1.25f;



    // Start is called before the first frame update
    void Start()
    {
        n = PoI - SC;

        Debug.Log(Ilumination().ToString("F5"));

        GameObject sph = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sph.transform.position = SC;
        sph.transform.localScale = new Vector3(SR*2,SR*2,SR*2);
        Renderer rend = sph.GetComponent<Renderer>();
        rend.material.shader = Shader.Find("Specular");
        rend.material.SetColor("_Color",new Color(kd.x, kd.y, kd.z));
        rend.material.SetColor("_SpecColor", new Color(ks.x, ks.y, ks.z));

        GameObject pointLight = new GameObject("ThePointLight");
        Light lightComp = pointLight.AddComponent<Light>();
        lightComp.type = LightType.Point;
        pointLight.transform.position = LIGHT;
        lightComp.color = new Color(Id.x, Id.y, Id.z);
        lightComp.intensity = 20;

        Camera.main.transform.position = CAMERA;
        Camera.main.transform.LookAt(PoI);

        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 l = LIGHT - PoI;
        Vector3 lp = n * Vector3.Dot(n.normalized,l);
        Vector3 lo = l - lp;
        Vector3 r = lp - lo;
        Vector3 v = CAMERA - PoI;

        Debug.DrawLine(PoI, PoI + l, Color.red);
        Debug.DrawLine(PoI, PoI + r, Color.magenta);
        Debug.DrawLine(PoI, PoI + n, Color.green);
        Debug.DrawLine(PoI, PoI + v, Color.red);

    }

    Vector3 Ilumination()
    {
        Vector3 A = new Vector3(ka.x * Ia.x, ka.y * Ia.y, ka.z * Ia.z);
        Vector3 D = new Vector3(kd.x * Id.x, kd.y * Id.y, kd.z * Id.z);
        Vector3 S = new Vector3(ks.x * Is.x, ks.y * Is.y, ks.z * Is.z);

        Vector3 l = LIGHT - PoI;
        Vector3 v = CAMERA - PoI;

        float dotNuLu = Vector3.Dot(n.normalized, l.normalized);

        float dotNuL = Vector3.Dot(n.normalized, l);

        Vector3 lp = n * dotNuL;
        Vector3 lo = l - lp;
        Vector3 r = lp - lo;
        D *= dotNuLu;
        S *= Mathf.Pow(Vector3.Dot(v.normalized, r.normalized),alpha);
        return A + D + S;


    }
}
