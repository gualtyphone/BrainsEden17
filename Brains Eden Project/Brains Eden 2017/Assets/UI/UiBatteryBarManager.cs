using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiBatteryBarManager : MonoBehaviour
{

    [SerializeField]
    private GameManager m_Gm;
    public EnergyContainer[] m_Container;

    private UiBar[] m_ImageBar;


    // Use this for initialization
    void Start()
    {
        m_ImageBar = GetComponentsInChildren<UiBar>();
        m_Container = new EnergyContainer[4];
    }

    // Update is called once per frame
    void Update()
    {
        if(m_Gm !=null)
        {
            for (int i=0;i<m_Container.Length;i++)
            {
                if(m_Container[i] != null)
                {
                    m_ImageBar[i].SetHealthBar(m_Container[i].energy, m_Container[i].maxEnergy);
                }
            }
        }
    }
}
