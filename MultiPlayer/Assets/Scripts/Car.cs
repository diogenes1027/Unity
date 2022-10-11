using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Car : MonoBehaviour
{
    [SerializeField] WheelCollider fr;
    [SerializeField] WheelCollider fl;
    [SerializeField] WheelCollider br;
    [SerializeField] WheelCollider bl;
    [SerializeField] Animator _animator;
    [SerializeField] AudioClip honk;

    public float acceleration = 500f;
    public float breakingforce = 300f;
    float turn = 15f;

    float currentacceleration = 0f;
    float currentbreakingforce = 0f;
    float currentturn = 0f;

    public Camera camera;

    AudioSource audio;

    AudioListener audioListener;
    AudioReverbFilter reverbFilter;
    AudioLowPassFilter audioLowPassFilter;
    PhotonView view;


    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        view = GetComponent<PhotonView>();

        audioListener = camera.GetComponent<AudioListener>();
        reverbFilter = camera.GetComponent<AudioReverbFilter>();
        audioLowPassFilter = camera.GetComponent<AudioLowPassFilter>();
        if (view.IsMine)
        {
            audioListener.enabled = true;
            reverbFilter.enabled = true;
            audioLowPassFilter.enabled = true;
            audio.enabled = true;
            camera.enabled = true;
        }
        else {
            camera.enabled = false;
            audioListener.enabled = false;
            reverbFilter.enabled = false;
            audioLowPassFilter.enabled = false;
            audio.enabled = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        

        
        if (view.IsMine) {
            currentacceleration = acceleration * Input.GetAxis("Vertical");

            

            if (Input.GetKey(KeyCode.Space))
            {
                currentbreakingforce = breakingforce;
                _animator.SetBool("ON", true);
            }

            else
            {
                currentbreakingforce = 0f;
                _animator.SetBool("ON", false);
            }


            fr.motorTorque = currentacceleration * 100f;
            fl.motorTorque = currentacceleration;
            bl.motorTorque = currentacceleration;
            bl.motorTorque = currentacceleration;

            fr.brakeTorque = currentbreakingforce;
            fl.brakeTorque = currentbreakingforce;
            br.brakeTorque = currentbreakingforce;
            bl.brakeTorque = currentbreakingforce;

            currentturn = turn * Input.GetAxis("Horizontal");
            fr.steerAngle = currentturn;
            fl.steerAngle = currentturn;
            br.steerAngle = -1f * currentturn;
            bl.steerAngle = -1f * currentturn;



            if (Input.GetKey(KeyCode.X)) gameObject.transform.localRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);

            if (Input.GetKey(KeyCode.C)) audio.PlayOneShot(honk, 0.2f);
        }
    }
        
}
