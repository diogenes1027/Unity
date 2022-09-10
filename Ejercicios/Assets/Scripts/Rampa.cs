using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rampa : MonoBehaviour
{
    [SerializeField] Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hola");
        _animator.SetBool("UP", true);
    }

    private void OnCollisionExit(Collision collision)
    {
        _animator.SetBool("UP", false);
    }
}
