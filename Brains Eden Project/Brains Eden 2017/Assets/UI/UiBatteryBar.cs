using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiBatteryBar : MonoBehaviour
{
    public EnergyContainer m_Container;
    private UiBar m_ImageBar;

    // Use this for initialization
    void Start()
    {
        m_ImageBar = GetComponentInChildren<UiBar>();
        m_Container = GetComponent<EnergyContainer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Container != null)
        {
            m_ImageBar.SetHealthBar(m_Container.energy, m_Container.maxEnergy);
        }
    }
}
