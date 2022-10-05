using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour
{

    List<GameObject> go_parts;
    List<Matrix4x4> m_locations;
    List<Matrix4x4> m_scales;
    List<Matrix4x4> m_rotations;
    Vector3[] v3_originals;

    float deltaY, dirY, rotY;

    enum PARTS
    {

        //RP_HEAP, LTHIGH, RTHIGH, LLEG, RLEG, LFOOT, RFOOT, RP_TORSO, RP_CHEST, RP_NECK, RP_HEAD
        RP_HEAP, LTHIGH, LLEG, LFOOT
    };

    // Start is called before the first frame update
    void Start()
    {

        rotY = 0f;
        dirY = 1;
        deltaY = 0.5f;

        go_parts = new List<GameObject>();
        m_scales = new List<Matrix4x4>();
        m_locations = new List<Matrix4x4>();
        m_rotations = new List<Matrix4x4>();

        //HEAP
        go_parts.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));
        v3_originals = go_parts[(int)PARTS.RP_HEAP].GetComponent<MeshFilter>().mesh.vertices;

        go_parts[(int)PARTS.RP_HEAP].GetComponent<MeshRenderer>().material.SetColor("_Color", Color.grey);
        go_parts[(int)PARTS.RP_HEAP].name = "HEAP";
        go_parts[(int)PARTS.RP_HEAP].GetComponent<BoxCollider>().enabled = false;

        m_scales.Add(Transformations.Scale(0.5f, 0.35f, 1f));
        m_locations.Add(Transformations.Translate(0f, 0f, 0f));
        m_rotations.Add(Transformations.RotateY(0f));

        //LEFT THIGH
        go_parts.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));

        go_parts[(int)PARTS.LTHIGH].GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
        go_parts[(int)PARTS.LTHIGH].name = "LTHIGH";
        go_parts[(int)PARTS.LTHIGH].GetComponent<BoxCollider>().enabled = false;

        m_scales.Add(Transformations.Scale(0.4f, 0.6f, 0.4f));
        m_locations.Add(Transformations.Translate(0f, -0.478f, 0.32f));
        m_rotations.Add(Transformations.RotateY(0f));

        //LEFT LEG
        go_parts.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));

        go_parts[(int)PARTS.LLEG].GetComponent<MeshRenderer>().material.SetColor("_Color", Color.blue);
        go_parts[(int)PARTS.LLEG].name = "LLEG";
        go_parts[(int)PARTS.LLEG].GetComponent<BoxCollider>().enabled = false;

        m_scales.Add(Transformations.Scale(0.5f, 0.7f, 0.5f));
        m_locations.Add(Transformations.Translate(0f, -0.642f, 0.01f));
        m_rotations.Add(Transformations.RotateY(0f));

        //LEFT FOOT
        go_parts.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));

        go_parts[(int)PARTS.LFOOT].GetComponent<MeshRenderer>().material.SetColor("_Color", Color.blue);
        go_parts[(int)PARTS.LFOOT].name = "LFOOT";
        go_parts[(int)PARTS.LFOOT].GetComponent<BoxCollider>().enabled = false;

        m_scales.Add(Transformations.Scale(0.7f, 0.3f, 0.5f));
        m_locations.Add(Transformations.Translate(-0.103f, -0.976f, 0));
        m_rotations.Add(Transformations.RotateY(0f));


        /*
        //RIGHT THIGH
        go_parts.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));

        go_parts[(int)PARTS.RTHIGH].GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
        go_parts[(int)PARTS.RTHIGH].name = "RTHIGH";
        go_parts[(int)PARTS.RTHIGH].GetComponent<BoxCollider>().enabled = false;

        m_scales.Add(Transformations.Scale(0.4f, 0.6f, 0.4f));
        m_locations.Add(Transformations.Translate(0f, 0f, -0.64f));
        m_rotations.Add(Transformations.RotateY(0f));

        
        //TORSO
        go_parts.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));

        go_parts[(int)PARTS.RP_TORSO].GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
        go_parts[(int)PARTS.RP_TORSO].name = "TORSO";
        go_parts[(int)PARTS.RP_TORSO].GetComponent<BoxCollider>().enabled = false;

        m_scales.Add(Transformations.Scale(1f, 0.75f, 1f));
        m_locations.Add(Transformations.Translate(0f, 0.25f + 0.75f / 2f, 0f));


        m_rotations.Add(Transformations.RotateY(0f));

        //CHEST
        go_parts.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));

        go_parts[(int)PARTS.RP_CHEST].GetComponent<MeshRenderer>().material.SetColor("_Color", Color.red);
        go_parts[(int)PARTS.RP_CHEST].name = "CHEST";
        go_parts[(int)PARTS.RP_CHEST].GetComponent<BoxCollider>().enabled = false;

        m_scales.Add(Transformations.Scale(1.2f, 0.4f, 1.2f));
        m_locations.Add(Transformations.Translate(0f, 0.75f / 2f + 0.2f, 0f));

        m_rotations.Add(Transformations.RotateY(0f));

        //NECK
        go_parts.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));
        go_parts[(int)PARTS.RP_NECK].GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
        go_parts[(int)PARTS.RP_NECK].name = "NECK";
        go_parts[(int)PARTS.RP_NECK].GetComponent<BoxCollider>().enabled = false;
        m_scales.Add(Transformations.Scale(0.1f, 0.2f, 0.2f));
        m_locations.Add(Transformations.Translate(0f, 0.2f + 0.1f / 2f, 0f));


        m_rotations.Add(Transformations.RotateY(0f));

        //HEAD
        go_parts.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));
        go_parts[(int)PARTS.RP_HEAD].GetComponent<MeshRenderer>().material.SetColor("_Color", Color.blue);
        go_parts[(int)PARTS.RP_HEAD].name = "HEAD";
        go_parts[(int)PARTS.RP_HEAD].GetComponent<BoxCollider>().enabled = false;
        m_scales.Add(Transformations.Scale(0.3f, 0.3f, 0.3f));
        m_locations.Add(Transformations.Translate(0f, 0.1f / 2f + 0.3f / 2f, 0f));


        m_rotations.Add(Transformations.RotateY(0f));


        */
    }

    // Update is called once per frame
    void Update()
    {
        rotY += deltaY * dirY;
        if (rotY <= -45f || rotY >= 45f) dirY = -dirY;

        Matrix4x4 accumT = Matrix4x4.identity;

        for (int i = 0; i < go_parts.Count; i++)
        {
            Matrix4x4 m = accumT * m_locations[i] * m_rotations[i] * m_scales[i];
            /*if (i == (int)PARTS.RP_TORSO)
            {
                Matrix4x4 t1 = Transformations.Translate(0, 0.5f / 2f, 0);
                Matrix4x4 r = Transformations.RotateX(rotY);
                Matrix4x4 t2 = Transformations.Translate(0, 0.75f / 2f, 0);
                //m_rotations[i] = Transformations.RotateX(rotY);

                m = accumT * t1 * r * t2 * m_scales[i];
                accumT *= t1 * r * t2;
            }
            else
            {

                accumT *= m_locations[i] * m_rotations[i];
            }*/

            accumT *= m_locations[i] * m_rotations[i];


            go_parts[i].GetComponent<MeshFilter>().mesh.vertices = Transformations.Transform(m, v3_originals);
            //go_parts[i].GetComponent<MeshFilter>().mesh.
        }
    }
}
