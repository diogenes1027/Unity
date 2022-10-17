using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject playerPrefab;
    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < 100; i++)
        {

            float px = Random.Range(0.0f, 10.0f);
            float py = Random.Range(0.0f, 10.0f);
            float pz = Random.Range(0.0f, 10.0f);
            Vector3 p = new Vector3(px, py, pz);


            createSphere(p);


        }

    }

    void createSphere(Vector3 position) {
        PhotonNetwork.Instantiate(playerPrefab.name, position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
