using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rubik : MonoBehaviour
{

    List<GameObject> cubes;
    List<Vector3> positions;
    List<Matrix4x4> matrices;
    List<Matrix4x4> mOriginales;
    Vector3[] originales;
    float rotZ;



    float s = 1;


    
    // Start is called before the first frame update
    void Start()
    {
        rotZ = 0;

        float h = s / 2;

        positions.Add(new Vector3(h, h, h));
        positions.Add(new Vector3(h, h, -h));
        positions.Add(new Vector3(h, -h, h));
        positions.Add(new Vector3(h, -h, -h));
        positions.Add(new Vector3(-h, h, h));
        positions.Add(new Vector3(-h, h, -h));
        positions.Add(new Vector3(-h, -h, h));
        positions.Add(new Vector3(-h, -h, -h));

        originales = cubes[0].GetComponent<MeshFilter>().mesh.vertices;

        for (int i = 0; i < cubes.Count; i++) {
            mOriginales.Add(Transformations.Translate(positions[i].x,positions[i].y, positions[i].z));
            matrices.Add(mOriginales[i]);
        }
  

    }

    // Update is called once per frame
    void Update()
    {
        if (rotZ < 360.0f) {
            //rot
        }
        
    }
}
