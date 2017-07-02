using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAnimations : MonoBehaviour
{
    public GameObject m_titleText;
    public GameObject m_endPos;
    public float m_moveSpeed;
    private Vector3 m_titleTextEndPos;

    public MainMenuController m_menuControl;

    // Use this for initialization
    private void Start()
    {
        m_titleTextEndPos = m_endPos.transform.position;
        m_menuControl.HideShowButtons(true);
    }

    // Update is called once per frame
    private void Update()
    {
        if (m_titleText.transform.position != m_titleTextEndPos)
        {
            m_titleText.transform.position = Vector3.MoveTowards(m_titleText.transform.position, m_titleTextEndPos, m_moveSpeed * Time.deltaTime);
        }
        else
        {
            m_menuControl.HideShowButtons(false);
        }
    }
}