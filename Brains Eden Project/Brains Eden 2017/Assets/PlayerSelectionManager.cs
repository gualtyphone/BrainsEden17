using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelectionManager : MonoBehaviour {
    [SerializeField]
    GameManager GM;

    [SerializeField]
    GameObject[] panels;

    [SerializeField]
    Text[] readyText; 


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < GM.Players.Length; i++)
        {
            panels[i].SetActive(GM.Players[i]);
            if (GM.Players[i])
            {
                readyText[i].text = GM.playersReady[i] ? "READY!" : "Press A when ready";
            }
        }
    }
}
