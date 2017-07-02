using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{

    [SerializeField]
    public GameManager m_GM;

    public EnergyContainer[] containers;
    public UiBar[] m_UIScript;

    public Image[] m_ImageBar;
    public GameObject[] m_Go;


    // Use this for initialization
    void Start()
    {
        containers = new EnergyContainer[4];
        m_UIScript = new UiBar[4];

        for (int i = 0; i < m_ImageBar.Length; i++)
        {
            m_UIScript[i] = m_ImageBar[i].GetComponent<UiBar>();
        }

        for (int i = 0; i < m_Go.Length; i++)
        {
            m_Go[i].SetActive(false);
        }

        

    }

    // Update is called once per frame
    void Update()
    {
        if (m_GM != null)
        {
            for (int i = 0; i < m_GM.Players.Length; i++)
            {
                if (m_GM.Players[i] != null)
                {
                    if (containers[i] != null)
                    {
                        m_UIScript[i].SetHealthBar(containers[i].energy, containers[i].maxEnergy);
                        m_Go[i].SetActive(true);
                    }
                   
                }
            }
        }
    }
}
