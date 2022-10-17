using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRoomController : MonoBehaviour
{
    public Text score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "";

        foreach (Player p in PhotonNetwork.PlayerList)
        {
            score.text += p.NickName + ": " + p.GetScore().ToString() + "    ";
        }
    }
}
