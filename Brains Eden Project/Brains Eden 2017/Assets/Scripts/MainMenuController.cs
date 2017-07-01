using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Button[] m_buttons;
    public Image[] m_buttonImages;

    public Color m_selected;
    public Color m_unselected;
    private int m_currentButtonId;

    public float m_moveSpeed;
    private float m_moveTimer;

    // Use this for initialization
    private void Start()
    {
        m_currentButtonId = 0;
        UpdateButtons();
        m_moveTimer = 0f;
    }

    private void Update()
    {
        CheckForTextChange();
        CheckForSceneChange();
    }

    private void UpdateButtons()
    {
        for (int i = 0; i < m_buttons.Length; i++)
        {
            if (i == m_currentButtonId)
            {
                m_buttonImages[i].color = m_selected;
            }
            else
            {
                m_buttonImages[i].color = m_unselected;
            }
        }
    }

    private void CheckForTextChange()
    {
        print(m_currentButtonId);
        m_moveTimer += Time.deltaTime;
        if (Input.GetAxis("Vertical") < 0f && m_moveTimer >= m_moveSpeed)
        {
            print("move down");
            m_currentButtonId++;
            if (m_currentButtonId >= m_buttons.Length)
            {
                m_currentButtonId = 0;
            }
            UpdateButtons();
            m_moveTimer = 0f;
        }
        else if (Input.GetAxis("Vertical") > 0f && m_moveTimer >= m_moveSpeed)
        {
            print("move Up");
            m_currentButtonId--;
            if (m_currentButtonId <= 0)
            {
                m_currentButtonId = m_buttons.Length - 1;
            }
            UpdateButtons();
            m_moveTimer = 0f;
        }
    }

    private void CheckForSceneChange()
    {
        if (Input.GetButtonDown("Submit"))
        {
            switch (m_currentButtonId)
            {
                case 0:
                    SceneLoader.m_sceneLoader.LoadArena1();
                    break;

                case 1:
                    SceneLoader.m_sceneLoader.ExitGame();
                    break;

                default:
                    Debug.LogError("Invalid ID");
                    break;
            }
        }
    }
}