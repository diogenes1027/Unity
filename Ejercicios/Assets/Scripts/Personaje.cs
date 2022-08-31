using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    private AudioManager audioManager;
    // Start is called before the first frame update
    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) {

            audioManager.AudioSelect(0, 0.5f);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {

            audioManager.AudioSelect(1, 0.5f);
        }
    }
}
