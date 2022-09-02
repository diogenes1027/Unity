using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DoorScript : MonoBehaviour
{
    private Animator _animator;
    private AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && _animator.GetBool("Open") == false) {
            _animator.SetBool("Open", true);
            audioManager.AudioSelect(0, 0.5f);
        }

        else if (Input.GetKeyDown(KeyCode.A) && _animator.GetBool("Open") == true)
        {
            _animator.SetBool("Open", false);
            audioManager.AudioSelect(1, 0.5f);
        }
    }
}
