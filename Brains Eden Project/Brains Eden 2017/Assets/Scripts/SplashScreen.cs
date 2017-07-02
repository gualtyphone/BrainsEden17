using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreen : MonoBehaviour
{
    public float m_splashTime;
    private float m_splashTimer;

    public GameObject m_controls;

    // Use this for initialization
    private void Start()
    {
        m_splashTimer = 0f;
    }

    // Update is called once per frame
    private void Update()
    {
        m_splashTimer += Time.deltaTime;
        if (m_splashTimer < m_splashTime / 2)
        {
            m_controls.SetActive(true);
        }
        else
        {
            m_controls.SetActive(false);
        }

        if (m_splashTimer >= m_splashTime)
        {
            SceneLoader.m_sceneLoader.LoadArena1();
        }
    }
}