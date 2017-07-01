using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourFade : MonoBehaviour
{
    public GameObject[] m_outsideWalls;
    public Renderer[] m_renderers;

    public Color m_colour;
    public Color m_endColour;

    public float m_fadeSpeed;
    private float m_fadeTime;

    // Use this for initialization
    private void Start()
    {
        //m_colour = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        for (int i = 0; i < m_renderers.Length; i++)
        {
            m_renderers[i].material.color = m_colour;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        float t_lerp = Mathf.PingPong(Time.time, m_fadeSpeed) / m_fadeSpeed;
        for (int i = 0; i < m_renderers.Length; i++)
        {
            m_renderers[i].material.color = Color.Lerp(m_colour, m_endColour, t_lerp);
        }
    }
}