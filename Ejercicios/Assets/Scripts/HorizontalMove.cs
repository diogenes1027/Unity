using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMove : MonoBehaviour
{

    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Vec = transform.localPosition;

        if (Input.GetAxis("Horizontal") > 0)
        {
            Vec.x += Input.GetAxis("Horizontal") * Time.deltaTime * 10;
            
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            Vec.x += Input.GetAxis("Horizontal") * Time.deltaTime * 10;
            
        }
        

        transform.localPosition = Vec;
    }

    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "Platform1")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            audioManager.AudioSelect(0, 0.5f);
        }
        if (collision.gameObject.name == "Platform2")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            audioManager.AudioSelect(1, 0.5f);
        }


    }
}

