using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimeLineButton : MonoBehaviour
{
    public PlayableDirector timeline;

    // Use this for initialization
    void Start()
    {
        timeline = GetComponent<PlayableDirector>();
        
    }


    private void Update()
    {
        if (Input.GetKey(KeyCode.Space)) timeline.Play();

        else if (Input.GetKey(KeyCode.X)) {

            timeline.time = 2;
            timeline.Stop();
            timeline.Evaluate();
        }

        
    }

    
}
