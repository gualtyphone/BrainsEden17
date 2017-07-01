using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{

    [SerializeField]
    public GameManager m_GM;

    public EnergyContainer[] containers;

    public UiBar[] m_ImageBar;


    // Use this for initialization
    void Start()
    {
        containers = new EnergyContainer[4];
       // m_ImageBar = new Image[4];
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < m_GM.Players.Length; i++)
        {
            if (m_GM.Players[i] != null)
            {
                if (containers[i] != null)
                {
                    m_ImageBar[i].SetHealthBar(containers[i].energy, containers[i].maxEnergy);
                }
            }
        }
    }
}
