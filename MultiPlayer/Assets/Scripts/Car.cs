using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Pun.UtilityScripts;

public class Car : MonoBehaviour
{
    [SerializeField] WheelCollider fr;
    [SerializeField] WheelCollider fl;
    [SerializeField] WheelCollider br;
    [SerializeField] WheelCollider bl;
    [SerializeField] Animator _animator;
    [SerializeField] AudioClip honk;

    public float acceleration = 500f;
    public float breakingforce = 700f;
    float turn = 15f;

    float currentacceleration = 0f;
    float currentbreakingforce = 0f;
    float currentturn = 0f;

    public Camera camera;
    public Text name;

    AudioSource audio;

    AudioListener audioListener;
    AudioReverbFilter reverbFilter;
    AudioLowPassFilter audioLowPassFilter;
    PhotonView view;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Player";
        audio = GetComponent<AudioSource>();
        view = GetComponent<PhotonView>();
        //view.Owner.NickName = "Car 1";

        name.text = view.Owner.NickName;

        //Debug.Log();


        audioListener = camera.GetComponent<AudioListener>();
        reverbFilter = camera.GetComponent<AudioReverbFilter>();
        audioLowPassFilter = camera.GetComponent<AudioLowPassFilter>();
        if (view.IsMine)
        {
            name.enabled = true;
            audioListener.enabled = true;
            reverbFilter.enabled = true;
            audioLowPassFilter.enabled = true;
            audio.enabled = true;
            camera.enabled = true;
        }
        else {
            name.enabled = false;
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

            //Debug.Log(view.Owner.NickName);
        
            currentacceleration = acceleration * Input.GetAxis("Vertical");


            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.JoystickButton0))
            {
                currentbreakingforce = breakingforce;
                _animator.SetBool("ON", true);
            }

            else
            {
                currentbreakingforce = 0f;
                _animator.SetBool("ON", false);
            }


            fr.motorTorque = currentacceleration;
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



            if (Input.GetKey(KeyCode.X) || Input.GetKey(KeyCode.JoystickButton2)) gameObject.transform.localRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);

            if (Input.GetKey(KeyCode.C) || Input.GetKey(KeyCode.JoystickButton1)) audio.PlayOneShot(honk, 0.2f);
        }
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Collectable"))
        {
            view.Owner.AddScore(1);
        }
    }

}
