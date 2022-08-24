using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
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
        Vector3 Vec = transform.localPosition;

        if (Input.GetAxis("Horizontal") > 0)
        {
            Vec.x += Input.GetAxis("Horizontal") * Time.deltaTime * 20;
            _animator.SetBool("Right", true);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            Vec.x += Input.GetAxis("Horizontal") * Time.deltaTime * 20;
            _animator.SetBool("Left", true);
        }
        else {
            _animator.SetBool("Right", false);
            _animator.SetBool("Left", false);
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            _animator.SetBool("Front", true);
            
            Vec.z += Input.GetAxis("Vertical") * Time.deltaTime * 20;
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            Vec.z += Input.GetAxis("Vertical") * Time.deltaTime * 20;
            _animator.SetBool("Back", true);
        }
        else {
            _animator.SetBool("Front", false);
            _animator.SetBool("Back", false);
        }
        transform.localPosition = Vec;
    }
}
