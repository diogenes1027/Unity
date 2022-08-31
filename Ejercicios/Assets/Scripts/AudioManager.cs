using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] sonidos;
    private AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    public void AudioSelect(int clip, float volume) {

        audio.Stop();
        audio.PlayOneShot(sonidos[clip],volume);
    }

}
