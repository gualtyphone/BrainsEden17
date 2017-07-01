using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UiPlayerBar : MonoBehaviour
{
    public EnergyContainer m_Ec;

    public UiBar[] m_UiBar;

    public Image[] m_Bar;

    void Start()
    {
        m_Ec = gameObject.GetComponent<EnergyContainer>();
        m_UiBar = gameObject.GetComponentsInChildren<UiBar>();

      /*  m_Bar = gameObject.GetComponentsInChildren<Image>();
        for (int i = 0; i < m_Bar.Length; i++)
        {
            m_Bar[i].color = gameObject.GetComponent<PlayerController>().playerColor;
        }*/
    }


    void Update()
    {
        for (int i = 0; i < m_UiBar.Length; i++)
        {
            m_UiBar[i].SetHealthBar(m_Ec.energy, m_Ec.maxEnergy);
        }
    }
}
