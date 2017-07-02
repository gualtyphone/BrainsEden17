using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimeText : MonoBehaviour {

    public Text m_text;
    public GameManager m_manager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (m_manager.state == GameState.Game)
        {
            m_text.text = "Time Left: " + m_manager.GetTimeLeft();
        }
        else
        {
            m_text.text = "";
        }
	}
}
