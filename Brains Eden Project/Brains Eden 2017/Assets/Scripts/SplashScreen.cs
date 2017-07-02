using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreen : MonoBehaviour
{
    public float m_splashTime;
    private float m_splashTimer;

    // Use this for initialization
    private void Start()
    {
        m_splashTimer = 0f;
    }

    // Update is called once per frame
    private void Update()
    {
        m_splashTimer += Time.deltaTime;
        if (m_splashTimer >= m_splashTime)
        {
            SceneLoader.m_sceneLoader.LoadArena1();
        }
    }
}