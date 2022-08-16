using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Octahedron : MonoBehaviour
{
    //Structure that stores a geometry and topology for a figure
    struct Shape
    {
        public Vector3[] geometry;
        public int[] topology;
    };


    //Concatenates two arrays of ints
    int[] JoinI(int[] a, int[] b)
    {

        int[] z = new int[a.Length + b.Length];
        a.CopyTo(z, 0);
        b.CopyTo(z, a.Length);
        return z;

    }

    //Concatenate two arrays of Vector3
    Vector3[] JoinV(Vector3[] a, Vector3[] b)
    {

        Vector3[] z = new Vector3[a.Length + b.Length];
        a.CopyTo(z, 0);
        b.CopyTo(z, a.Length);
        return z;

    }

    //Creates a Triangle with its 3 vertices and the topology
    Shape factory(Vector3 a, Vector3 b, Vector3 c, int p1, int p2, int p3)
    {

        Shape result = new Shape();

        result.geometry = new Vector3[] { a, b, c };
        result.topology = new int[] { p1, p2, p3 };

        return result;
    }

    //Tessellates a triangle into 4 triangles
    Shape Tessellate(Shape input, int i)
    {
        Vector3[] originalG = input.geometry;
        int[] originalT = input.topology;

        Vector3 A = originalG[0];
        Vector3 B = originalG[1];
        Vector3 C = originalG[2];
        Vector3 o = ((A + B) / 2);
        Vector3 p = ((B + C) / 2);
        Vector3 q = ((A + C) / 2);
        Vector3[] resultG = new Vector3[6] { A, B, C, o, p, q };
        int[] resultT = new int[12] { 0 + 6 * i, 3 + 6 * i, 5 + 6 * i, 3 + 6 * i, 1 + 6 * i, 4 + 6 * i, 5 + 6 * i, 4 + 6 * i, 2 + 6 * i, 3 + 6 * i, 4 + 6 * i, 5 + 6 * i };

        Shape result = new Shape();
        result.geometry = resultG;
        result.topology = resultT;

        return result;
    }


    //Gets a Shape and distributes its triangles to tesselate each of them
    Shape Octa(Shape input)
    {
        Shape result = new Shape();

        result.geometry = new Vector3[] { };
        result.topology = new int[] { };

        Shape temp = new Shape();

        for (int i = 0; i < input.topology.Length; i += 3)
        {
            //Creates a triangle with the
            temp = factory(input.geometry[input.topology[i]], input.geometry[input.topology[i + 1]], input.geometry[input.topology[i + 2]], input.topology[i], input.topology[i + 1], input.topology[i + 2]);

            temp = Tessellate(temp, i / 3);

            result.geometry = JoinV(result.geometry, temp.geometry);
            result.topology = JoinI(result.topology, temp.topology);

        }

        return result;
    }

    // Start is called before the first frame update
    void Start()
    {
        /*
        Shape i = new Shape();
        i.geometry = new Vector3[3] {
            new Vector3(0, 0, 1),
            new Vector3(1,0,0),
            new Vector3(0,1,0)
        };
        i.topology = new int[3] { 0,1,2};
        Shape o = Tessellate(i,1);
        foreach (Vector3 v in o.geometry) Debug.Log(v);
        foreach (int index in o.topology) Debug.Log(index);
        */

        Mesh mymesh = new Mesh();
        
        Vector3[] vertices = new Vector3[]{
            new Vector3(1,0,0),
            new Vector3(0,0,1),
            new Vector3(-1,0,0),
            new Vector3(0,0,-1),
            new Vector3(0,1,0),
            new Vector3(0,-1,0)

        };

        int[] tris = new int[24] { 1, 0, 4, 0, 3, 4, 3, 2, 4, 2, 1, 4, 5, 0, 1, 5, 3, 0, 5, 2, 3, 5, 1, 2 };

        Shape octahedron = new Shape();

        octahedron.geometry = vertices;
        octahedron.topology = tris;

        octahedron = Octa(octahedron);
        octahedron = Octa(octahedron);
        octahedron = Octa(octahedron);
        



        mymesh.vertices = octahedron.geometry;
        mymesh.triangles = octahedron.topology;



        /*
        mymesh.vertices = vertices;
        mymesh.triangles = tris;
         

        mymesh.vertices = o.geometry;
        mymesh.triangles = o.topology;
        */




        mymesh.RecalculateNormals();

        MeshRenderer mr = gameObject.AddComponent<MeshRenderer>();
        mr.material = new Material(Shader.Find("Diffuse"));

        MeshFilter mf = gameObject.AddComponent<MeshFilter>();
        mf.mesh = mymesh;



    }

    // Update is called once per frame
    void Update()
    {

    }
}