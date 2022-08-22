using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DoorScript : MonoBehaviour
{
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && _animator.GetBool("Open") == false) {
            _animator.SetBool("Open", true);
        }

        else if (Input.GetKeyDown(KeyCode.A) && _animator.GetBool("Open") == true)
        {
            _animator.SetBool("Open", false);
        }
    }
}
