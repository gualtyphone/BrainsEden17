using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outline : MonoBehaviour
{
    public Renderer[] m_renderers;

    // Use this for initialization
    private void Start()
    {
        TurnOutlineOff();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            print("turning off");
            TurnOutlineOff();
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            print("turning on");
            TurnOutlineOn();
        }
    }

    public void TurnOutlineOff()
    {
        for (int i = 0; i < m_renderers.Length; i++)
        {
            m_renderers[i].materials[1].SetFloat("_Outline", 0f);
        }
    }

    public void TurnOutlineOn()
    {
        for (int i = 0; i < m_renderers.Length; i++)
        {
            m_renderers[i].materials[1].SetFloat("_Outline", .03f);
        }
    }
}