using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{

    public GameObject[] m_GO;
    public GameManager m_GM;


    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < m_GO.Length; i++)
        {
            m_GO[i].SetActive(false);
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
                    m_GO[i].SetActive(true);
                    m_GO[i].GetComponentInChildren<speedo>().setSpedo(m_GM.Players[i].GetComponent<EnergyContainerPlayer>().energy);
                }




                //set energy for player i



            }
        }
    }


}
