using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiAbovePlayer : MonoBehaviour
{
    public Image m_canvas;
    public Rigidbody m_RB;
    public Sprite m_Plus;
    public Sprite m_Minus;
    public Sprite m_Empty;

    public void Start()
    {
        m_canvas = GetComponentInChildren<Image>();
        m_canvas.sprite = m_Empty;
        m_RB = GetComponent<Rigidbody>();
        m_RB.useGravity = false;
        m_RB.freezeRotation = true;
    }

    //public void Update()
    //{
    //    if (Input.GetKey(KeyCode.A))
    //        Plus();
    //    else if (Input.GetKey(KeyCode.S))
    //        Minus();
    //    else
    //        Empty();
    //}

    // Update is called once per frame
    public void Plus()
    {
        m_canvas.sprite = m_Plus;
    }
    public void Minus()
    {
        m_canvas.sprite = m_Minus;
    }
    public void Empty()
    {
        m_canvas.sprite = m_Empty;
    }

}
