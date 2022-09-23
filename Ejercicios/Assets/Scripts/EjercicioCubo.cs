using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjercicioCubo : MonoBehaviour
{
    float h = 1.75f;

    

    // Start is called before the first frame update
    void Start()
    {
        Vector4[] vertices = new Vector4[]{
            new Vector4(h,h,h,1),
            new Vector4(h,h,-h,1),
            new Vector4(h,-h,h,1),
            new Vector4(h,-h,-h,1),
            new Vector4(-h,h,h,1),
            new Vector4(-h,h,-h,1),
            new Vector4(-h,-h,h,1),
            new Vector4(-h,-h,-h,1)
        };

        foreach (Vector4 v in vertices) {
            Debug.Log(v.ToString("F5"));
        }
        
        Matrix4x4 rz = Transformations.RotateZ(-15.63f);
        Matrix4x4 tz = Transformations.Translate(0,0,12.77f);
        Matrix4x4 ry = Transformations.RotateY(2.48f);

        foreach (Vector4 v in vertices)
        {
            Vector4 q = rz * tz * ry * v;
           
            Debug.Log(q.ToString("F5"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
