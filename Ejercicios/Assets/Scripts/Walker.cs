using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour
{

    List<GameObject> leftLeg;
    List<GameObject> rightLeg;
    List<GameObject> leftArm;
    List<GameObject> rightArm;
    List<GameObject> head;

    List<Matrix4x4> ll_locations;
    List<Matrix4x4> ll_scales;
    List<Matrix4x4> ll_rotations;

    List<Matrix4x4> rl_locations;
    List<Matrix4x4> rl_scales;
    List<Matrix4x4> rl_rotations;

    List<Matrix4x4> la_locations;
    List<Matrix4x4> la_scales;
    List<Matrix4x4> la_rotations;

    List<Matrix4x4> ra_locations;
    List<Matrix4x4> ra_scales;
    List<Matrix4x4> ra_rotations;

    List<Matrix4x4> h_locations;
    List<Matrix4x4> h_scales;
    List<Matrix4x4> h_rotations;

    Vector3[] v3_originals;

    float deltaY, dirY, rotY;

    enum PARTS
    {

        //RP_HEAP, LTHIGH, RTHIGH, LLEG, RLEG, LFOOT, RFOOT, RP_TORSO, RP_CHEST, RP_NECK, RP_HEAD
        RP_HEAP, LTHIGH, LLEG, LFOOT, RTHIGH, RLEG, RFOOT, RP_TORSO, RP_CHEST, RP_NECK, RP_HEAD, LSHOULDER, LARM, LFOREARM,LHAND, RSHOULDER, RARM, RFOREARM, RHAND
    };

    // Start is called before the first frame update
    void Start()
    {

        rotY = 0f;
        dirY = 1;
        deltaY = 0.5f;

        leftLeg = new List<GameObject>();
        rightLeg = new List<GameObject>();
        leftArm = new List<GameObject>();
        rightArm = new List<GameObject>();
        head = new List<GameObject>();

        ll_scales = new List<Matrix4x4>();
        ll_locations = new List<Matrix4x4>();
        ll_rotations = new List<Matrix4x4>();

        rl_scales = new List<Matrix4x4>();
        rl_locations = new List<Matrix4x4>();
        rl_rotations = new List<Matrix4x4>();

        la_scales = new List<Matrix4x4>();
        la_locations = new List<Matrix4x4>();
        la_rotations = new List<Matrix4x4>();

        ra_scales = new List<Matrix4x4>();
        ra_locations = new List<Matrix4x4>();
        ra_rotations = new List<Matrix4x4>();

        h_scales = new List<Matrix4x4>();
        h_locations = new List<Matrix4x4>();
        h_rotations = new List<Matrix4x4>();

        //HEAP
        leftLeg.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));
        rightLeg.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));
        head.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));
        leftArm.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));
        rightArm.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));

        v3_originals = leftLeg[(int)PARTS.RP_HEAP].GetComponent<MeshFilter>().mesh.vertices;

        leftLeg[(int)PARTS.RP_HEAP].GetComponent<MeshRenderer>().material.SetColor("_Color", Color.grey);
        leftLeg[(int)PARTS.RP_HEAP].name = "HEAP";
        leftLeg[(int)PARTS.RP_HEAP].GetComponent<BoxCollider>().enabled = false;

        rightLeg[(int)PARTS.RP_HEAP].GetComponent<MeshRenderer>().material.SetColor("_Color", Color.grey);
        rightLeg[(int)PARTS.RP_HEAP].name = "HEAP";
        rightLeg[(int)PARTS.RP_HEAP].GetComponent<BoxCollider>().enabled = false;

        head[(int)PARTS.RP_HEAP].GetComponent<MeshRenderer>().material.SetColor("_Color", Color.grey);
        head[(int)PARTS.RP_HEAP].name = "HEAP";
        head[(int)PARTS.RP_HEAP].GetComponent<BoxCollider>().enabled = false;

        leftArm[(int)PARTS.RP_HEAP].GetComponent<MeshRenderer>().material.SetColor("_Color", Color.grey);
        leftArm[(int)PARTS.RP_HEAP].name = "HEAP";
        leftArm[(int)PARTS.RP_HEAP].GetComponent<BoxCollider>().enabled = false;

        rightArm[(int)PARTS.RP_HEAP].GetComponent<MeshRenderer>().material.SetColor("_Color", Color.grey);
        rightArm[(int)PARTS.RP_HEAP].name = "HEAP";
        rightArm[(int)PARTS.RP_HEAP].GetComponent<BoxCollider>().enabled = false;

        ll_scales.Add(Transformations.Scale(0.5f, 0.35f, 1f));
        ll_locations.Add(Transformations.Translate(0f, 0f, 0f));
        ll_rotations.Add(Transformations.RotateY(0f));

        rl_scales.Add(Transformations.Scale(0.5f, 0.35f, 1f));
        rl_locations.Add(Transformations.Translate(0f, 0f, 0f));
        rl_rotations.Add(Transformations.RotateY(0f));

        h_scales.Add(Transformations.Scale(0.5f, 0.35f, 1f));
        h_locations.Add(Transformations.Translate(0f, 0f, 0f));
        h_rotations.Add(Transformations.RotateY(0f));

        la_scales.Add(Transformations.Scale(0.5f, 0.35f, 1f));
        la_locations.Add(Transformations.Translate(0f, 0f, 0f));
        la_rotations.Add(Transformations.RotateY(0f));

        ra_scales.Add(Transformations.Scale(0.5f, 0.35f, 1f));
        ra_locations.Add(Transformations.Translate(0f, 0f, 0f));
        ra_rotations.Add(Transformations.RotateY(0f));

        //LEFT THIGH
        leftLeg.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));

        leftLeg[(int)PARTS.LTHIGH].GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
        leftLeg[(int)PARTS.LTHIGH].name = "LTHIGH";
        leftLeg[(int)PARTS.LTHIGH].GetComponent<BoxCollider>().enabled = false;

        ll_scales.Add(Transformations.Scale(0.4f, 0.6f, 0.4f));
        ll_locations.Add(Transformations.Translate(0f, -0.478f, 0.32f));
        ll_rotations.Add(Transformations.RotateY(0f));

        //LEFT LEG
        leftLeg.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));

        leftLeg[(int)PARTS.LLEG].GetComponent<MeshRenderer>().material.SetColor("_Color", Color.blue);
        leftLeg[(int)PARTS.LLEG].name = "LLEG";
        leftLeg[(int)PARTS.LLEG].GetComponent<BoxCollider>().enabled = false;

        ll_scales.Add(Transformations.Scale(0.5f, 0.7f, 0.5f));
        ll_locations.Add(Transformations.Translate(0f, -0.642f, 0.01f));
        ll_rotations.Add(Transformations.RotateY(0f));

        //LEFT FOOT
        leftLeg.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));

        leftLeg[(int)PARTS.LFOOT].GetComponent<MeshRenderer>().material.SetColor("_Color", Color.blue);
        leftLeg[(int)PARTS.LFOOT].name = "LFOOT";
        leftLeg[(int)PARTS.LFOOT].GetComponent<BoxCollider>().enabled = false;

        ll_scales.Add(Transformations.Scale(0.7f, 0.3f, 0.5f));
        ll_locations.Add(Transformations.Translate(-0.103f, -0.498f, 0));
        ll_rotations.Add(Transformations.RotateY(0f));

        //RIGHT THIGH
        rightLeg.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));

        rightLeg[(int)PARTS.RTHIGH- (int)PARTS.LFOOT].GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
        rightLeg[(int)PARTS.RTHIGH- (int)PARTS.LFOOT].name = "RTHIGH";
        rightLeg[(int)PARTS.RTHIGH- (int)PARTS.LFOOT].GetComponent<BoxCollider>().enabled = false;

        rl_scales.Add(Transformations.Scale(0.4f, 0.6f, 0.4f));
        rl_locations.Add(Transformations.Translate(0f, -0.478f, -0.32f));
        rl_rotations.Add(Transformations.RotateY(0f));

        //RIGHT LEG
        rightLeg.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));

        rightLeg[(int)PARTS.RLEG - (int)PARTS.LFOOT].GetComponent<MeshRenderer>().material.SetColor("_Color", Color.blue);
        rightLeg[(int)PARTS.RLEG - (int)PARTS.LFOOT].name = "RLEG";
        rightLeg[(int)PARTS.RLEG - (int)PARTS.LFOOT].GetComponent<BoxCollider>().enabled = false;

        rl_scales.Add(Transformations.Scale(0.5f, 0.7f, 0.5f));
        rl_locations.Add(Transformations.Translate(0f, -0.642f, -0.01f));
        rl_rotations.Add(Transformations.RotateY(0f));

        //RIGHT FOOT
        rightLeg.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));

        rightLeg[(int)PARTS.RFOOT - (int)PARTS.LFOOT].GetComponent<MeshRenderer>().material.SetColor("_Color", Color.blue);
        rightLeg[(int)PARTS.RFOOT - (int)PARTS.LFOOT].name = "RFOOT";
        rightLeg[(int)PARTS.RFOOT - (int)PARTS.LFOOT].GetComponent<BoxCollider>().enabled = false;

        rl_scales.Add(Transformations.Scale(0.7f, 0.3f, 0.5f));
        rl_locations.Add(Transformations.Translate(-0.103f, -0.498f, 0));
        rl_rotations.Add(Transformations.RotateY(0f));

        //TORSO
        head.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));
        leftArm.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));
        rightArm.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));

        head[(int)PARTS.RP_TORSO - (int)PARTS.RFOOT].GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
        head[(int)PARTS.RP_TORSO - (int)PARTS.RFOOT].name = "RP_TORSO";
        head[(int)PARTS.RP_TORSO - (int)PARTS.RFOOT].GetComponent<BoxCollider>().enabled = false;

        leftArm[(int)PARTS.RP_TORSO - (int)PARTS.RFOOT].GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
        leftArm[(int)PARTS.RP_TORSO - (int)PARTS.RFOOT].name = "RP_TORSO";
        leftArm[(int)PARTS.RP_TORSO - (int)PARTS.RFOOT].GetComponent<BoxCollider>().enabled = false;

        rightArm[(int)PARTS.RP_TORSO - (int)PARTS.RFOOT].GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
        rightArm[(int)PARTS.RP_TORSO - (int)PARTS.RFOOT].name = "RP_TORSO";
        rightArm[(int)PARTS.RP_TORSO - (int)PARTS.RFOOT].GetComponent<BoxCollider>().enabled = false;

        h_scales.Add(Transformations.Scale(0.5f, 0.48f, 0.75f));
        h_locations.Add(Transformations.Translate(0f, 0.413f, 0f));
        h_rotations.Add(Transformations.RotateY(0f));

        la_scales.Add(Transformations.Scale(0.5f, 0.48f, 0.75f));
        la_locations.Add(Transformations.Translate(0f, 0.413f, 0f));
        la_rotations.Add(Transformations.RotateY(0f));

        ra_scales.Add(Transformations.Scale(0.5f, 0.48f, 0.75f));
        ra_locations.Add(Transformations.Translate(0f, 0.413f, 0f));
        ra_rotations.Add(Transformations.RotateY(0f));

        //CHEST
        head.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));
        leftArm.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));
        rightArm.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));

        head[(int)PARTS.RP_CHEST - (int)PARTS.RFOOT].GetComponent<MeshRenderer>().material.SetColor("_Color", Color.red);
        head[(int)PARTS.RP_CHEST - (int)PARTS.RFOOT].name = "RP_CHEST";
        head[(int)PARTS.RP_CHEST - (int)PARTS.RFOOT].GetComponent<BoxCollider>().enabled = false;

        leftArm[(int)PARTS.RP_CHEST - (int)PARTS.RFOOT].GetComponent<MeshRenderer>().material.SetColor("_Color", Color.red);
        leftArm[(int)PARTS.RP_CHEST - (int)PARTS.RFOOT].name = "RP_CHEST";
        leftArm[(int)PARTS.RP_CHEST - (int)PARTS.RFOOT].GetComponent<BoxCollider>().enabled = false;

        rightArm[(int)PARTS.RP_CHEST - (int)PARTS.RFOOT].GetComponent<MeshRenderer>().material.SetColor("_Color", Color.red);
        rightArm[(int)PARTS.RP_CHEST - (int)PARTS.RFOOT].name = "RP_CHEST";
        rightArm[(int)PARTS.RP_CHEST - (int)PARTS.RFOOT].GetComponent<BoxCollider>().enabled = false;

        h_scales.Add(Transformations.Scale(0.7f, 0.67f, 1.16f));
        h_locations.Add(Transformations.Translate(0f, 0.540f, 0f));
        h_rotations.Add(Transformations.RotateY(0f));

        la_scales.Add(Transformations.Scale(0.7f, 0.67f, 1.16f));
        la_locations.Add(Transformations.Translate(0f, 0.540f, 0f));
        la_rotations.Add(Transformations.RotateY(0f));

        ra_scales.Add(Transformations.Scale(0.7f, 0.67f, 1.16f));
        ra_locations.Add(Transformations.Translate(0f, 0.540f, 0f));
        ra_rotations.Add(Transformations.RotateY(0f));

        //NECK
        head.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));

        head[(int)PARTS.RP_NECK - (int)PARTS.RFOOT].GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
        head[(int)PARTS.RP_NECK - (int)PARTS.RFOOT].name = "RP_NECK";
        head[(int)PARTS.RP_NECK - (int)PARTS.RFOOT].GetComponent<BoxCollider>().enabled = false;

        h_scales.Add(Transformations.Scale(0.3f, 0.21f, 0.3f));
        h_locations.Add(Transformations.Translate(0f, 0.450f, 0f));
        h_rotations.Add(Transformations.RotateY(0f));

        //HEAD
        head.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));

        head[(int)PARTS.RP_HEAD - (int)PARTS.RFOOT].GetComponent<MeshRenderer>().material.SetColor("_Color", Color.blue);
        head[(int)PARTS.RP_HEAD - (int)PARTS.RFOOT].name = "RP_HEAD";
        head[(int)PARTS.RP_HEAD - (int)PARTS.RFOOT].GetComponent<BoxCollider>().enabled = false;

        h_scales.Add(Transformations.Scale(0.45f, 0.45f, 0.45f));
        h_locations.Add(Transformations.Translate(0f, 0.310f, 0f));
        h_rotations.Add(Transformations.RotateY(0f));

        //LEFT SHOULDER
        leftArm.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));

        leftArm[(int)PARTS.LSHOULDER - (int)PARTS.RP_HEAD + 2].GetComponent<MeshRenderer>().material.SetColor("_Color", Color.red);
        leftArm[(int)PARTS.LSHOULDER - (int)PARTS.RP_HEAD + 2].name = "LSHOULDER";
        leftArm[(int)PARTS.LSHOULDER - (int)PARTS.RP_HEAD + 2].GetComponent<BoxCollider>().enabled = false;

        la_scales.Add(Transformations.Scale(0.4f, 0.4f, 0.4f));
        la_locations.Add(Transformations.Translate(0f, 0.17f, 0.78f));
        la_rotations.Add(Transformations.RotateY(0f));

        //LEFT ARM
        leftArm.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));

        leftArm[(int)PARTS.LARM - (int)PARTS.RP_HEAD + 2].GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
        leftArm[(int)PARTS.LARM - (int)PARTS.RP_HEAD + 2].name = "LARM";
        leftArm[(int)PARTS.LARM - (int)PARTS.RP_HEAD + 2].GetComponent<BoxCollider>().enabled = false;

        la_scales.Add(Transformations.Scale(0.3f, 0.3f, 0.4f));
        la_locations.Add(Transformations.Translate(0f, 0f, 0.385f));
        la_rotations.Add(Transformations.RotateY(0f));

        //LEFT FOREARM
        leftArm.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));

        leftArm[(int)PARTS.LFOREARM - (int)PARTS.RP_HEAD + 2].GetComponent<MeshRenderer>().material.SetColor("_Color", Color.red);
        leftArm[(int)PARTS.LFOREARM - (int)PARTS.RP_HEAD + 2].name = "LFOREARM";
        leftArm[(int)PARTS.LFOREARM - (int)PARTS.RP_HEAD + 2].GetComponent<BoxCollider>().enabled = false;

        la_scales.Add(Transformations.Scale(0.4f, 0.4f, 0.7f));
        la_locations.Add(Transformations.Translate(0f, 0f, 0.533f));
        la_rotations.Add(Transformations.RotateY(0f));

        //LEFT HAND
        leftArm.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));

        leftArm[(int)PARTS.LHAND - (int)PARTS.RP_HEAD + 2].GetComponent<MeshRenderer>().material.SetColor("_Color", Color.blue);
        leftArm[(int)PARTS.LHAND - (int)PARTS.RP_HEAD + 2].name = "LHAND";
        leftArm[(int)PARTS.LHAND - (int)PARTS.RP_HEAD + 2].GetComponent<BoxCollider>().enabled = false;

        la_scales.Add(Transformations.Scale(0.3f, 0.3f, 0.3f));
        la_locations.Add(Transformations.Translate(0f, 0f, 0.509f));
        la_rotations.Add(Transformations.RotateY(0f));

        //RIGHT SHOULDER
        rightArm.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));

        rightArm[(int)PARTS.RSHOULDER - (int)PARTS.LHAND + 2].GetComponent<MeshRenderer>().material.SetColor("_Color", Color.red);
        rightArm[(int)PARTS.RSHOULDER - (int)PARTS.LHAND + 2].name = "RSHOULDER";
        rightArm[(int)PARTS.RSHOULDER - (int)PARTS.LHAND + 2].GetComponent<BoxCollider>().enabled = false;

        ra_scales.Add(Transformations.Scale(0.4f, 0.4f, 0.4f));
        ra_locations.Add(Transformations.Translate(0f, 0.17f, -0.78f));
        ra_rotations.Add(Transformations.RotateY(0f));

        //RIGHT ARM
        rightArm.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));

        rightArm[(int)PARTS.RARM - (int)PARTS.LHAND + 2].GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
        rightArm[(int)PARTS.RARM - (int)PARTS.LHAND + 2].name = "RARM";
        rightArm[(int)PARTS.RARM - (int)PARTS.LHAND + 2].GetComponent<BoxCollider>().enabled = false;

        ra_scales.Add(Transformations.Scale(0.3f, 0.3f, 0.4f));
        ra_locations.Add(Transformations.Translate(0f, 0f, -0.385f));
        ra_rotations.Add(Transformations.RotateY(0f));

        //RIGHT FOREARM
        rightArm.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));

        rightArm[(int)PARTS.RFOREARM - (int)PARTS.LHAND + 2].GetComponent<MeshRenderer>().material.SetColor("_Color", Color.red);
        rightArm[(int)PARTS.RFOREARM - (int)PARTS.LHAND + 2].name = "RFOREARM";
        rightArm[(int)PARTS.RFOREARM - (int)PARTS.LHAND + 2].GetComponent<BoxCollider>().enabled = false;

        ra_scales.Add(Transformations.Scale(0.4f, 0.4f, 0.7f));
        ra_locations.Add(Transformations.Translate(0f, 0f, -0.533f));
        ra_rotations.Add(Transformations.RotateY(0f));

        //RIGHT HAND
        rightArm.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));

        rightArm[(int)PARTS.RHAND - (int)PARTS.LHAND + 2].GetComponent<MeshRenderer>().material.SetColor("_Color", Color.blue);
        rightArm[(int)PARTS.RHAND - (int)PARTS.LHAND + 2].name = "RHAND";
        rightArm[(int)PARTS.RHAND - (int)PARTS.LHAND + 2].GetComponent<BoxCollider>().enabled = false;

        ra_scales.Add(Transformations.Scale(0.3f, 0.3f, 0.3f));
        ra_locations.Add(Transformations.Translate(0f, 0f, -0.509f));
        ra_rotations.Add(Transformations.RotateY(0f));
      
    }

    // Update is called once per frame
    void Update()
    {
        rotY += deltaY * dirY;
        if (rotY <= -45f || rotY >= 45f) dirY = -dirY;

        Matrix4x4 accumTll = Matrix4x4.identity;
        Matrix4x4 accumTrl = Matrix4x4.identity;
        Matrix4x4 accumTla = Matrix4x4.identity;
        Matrix4x4 accumTra = Matrix4x4.identity;
        Matrix4x4 accumTh = Matrix4x4.identity;

        for (int i = 0; i < rightLeg.Count; i++)
        {
            Matrix4x4 mll = accumTll * ll_locations[i] * ll_rotations[i] * ll_scales[i];
            Matrix4x4 mrl = accumTrl * rl_locations[i] * rl_rotations[i] * rl_scales[i];
            /*
            Matrix4x4 mla = accumTla * la_locations[i] * la_rotations[i] * la_scales[i];
            Matrix4x4 mra = accumTra * ra_locations[i] * ra_rotations[i] * ra_scales[i];
            Matrix4x4 mh = accumTh * h_locations[i] * h_rotations[i] * h_scales[i];


            */

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

            accumTll *= ll_locations[i] * ll_rotations[i];
            accumTrl *= rl_locations[i] * rl_rotations[i];

            leftLeg[i].GetComponent<MeshFilter>().mesh.vertices = Transformations.Transform(mll, v3_originals);
            rightLeg[i].GetComponent<MeshFilter>().mesh.vertices = Transformations.Transform(mrl, v3_originals);
            //go_parts[i].GetComponent<MeshFilter>().mesh.
        }


        
        for (int j = 0; j < head.Count; j++){
            
            Matrix4x4 mh = accumTh * h_locations[j] * h_rotations[j] * h_scales[j];

            accumTh *= h_locations[j] * h_rotations[j];
            

            head[j].GetComponent<MeshFilter>().mesh.vertices = Transformations.Transform(mh, v3_originals);
            
        }

        for (int i = 0; i < leftArm.Count; i++)
        {


            Matrix4x4 mla = accumTla * la_locations[i] * la_rotations[i] * la_scales[i];
            Matrix4x4 mra = accumTra * ra_locations[i] * ra_rotations[i] * ra_scales[i];

            
            accumTla *= la_locations[i] * la_rotations[i];
            accumTra *= ra_locations[i] * ra_rotations[i];

            
         
            /*
            if (i == 4)
            {
                Matrix4x4 t1 = Transformations.Translate(0, 0.5f / 2f, 0);
                Matrix4x4 r = Transformations.RotateX(rotY);
                Matrix4x4 t2 = Transformations.Translate(0, 0.75f / 2f, 0);
                //m_rotations[i] = Transformations.RotateX(rotY);


                mla = accumTla * t1 * r * t2 * la_scales[i];
                mra = accumTra * t1 * r * t2 * ra_scales[i];

                accumTla *= t1 * r * t2;
                accumTra *= t1 * r * t2;
            }
            else
            {

                accumTla *= la_locations[i] * la_rotations[i];
                accumTra *= ra_locations[i] * ra_rotations[i];
            }

            */


            leftArm[i].GetComponent<MeshFilter>().mesh.vertices = Transformations.Transform(mla, v3_originals);
            rightArm[i].GetComponent<MeshFilter>().mesh.vertices = Transformations.Transform(mra, v3_originals);
        }

    }
}
