using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{

    [SerializeField]
    public GameManager m_GM;

    public EnergyContainer[] containers;

    public Image[] m_ImageBar;
    public GameObject[] m_Images;


    // Use this for initialization
    void Start()
    {
        containers = new EnergyContainer[4];
        for (int i = 0; i < m_Images.Length; i++)
        {
            m_Images[i].SetActive(false);
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

                    m_ImageBar[i].GetComponent<UiBar>().SetHealthBar(m_GM.Players[i].GetComponent<EnergyContainer>().energy,
                                                                    m_GM.Players[i].GetComponent<EnergyContainer>().maxEnergy);
                    m_Images[i].SetActive(true);
                }
            }
        }
    }
}
