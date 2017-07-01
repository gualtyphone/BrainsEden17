using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnergyTransfer))]
[RequireComponent(typeof(EnergyContainerPlayer))]
[RequireComponent(typeof(Movment))]
[RequireComponent(typeof(PlayerAiming))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    public int playerNumber = 0;
    // 0 = faulty, players = 1-4

    public Color playerColor;
    private float pushTrigger;
    private float pullTrigger;

	// Use this for initialization
	void Start () {
        GetComponent<Movment>().ControllerNum = playerNumber;
        switch(playerNumber)
        {
            case 1:
                playerColor = Color.blue;
                break;
            case 2:
                playerColor = Color.green;
                break;
            case 3:
                playerColor = Color.red;
                break;
            case 4:
                playerColor = Color.yellow;
                break;
        }
        GetComponent<Renderer>().material.color = playerColor;
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetJoystickNames()[playerNumber-1].Contains("Xbox One"))
        {
            pushTrigger = (Input.GetAxis("RTrigger" + playerNumber)+1);
        }
        else
        {
            pushTrigger = -(Input.GetAxis("LTrigger" + playerNumber));
        }

        if (Input.GetJoystickNames()[playerNumber-1].Contains("Xbox One"))
        {
            pullTrigger = (Input.GetAxis("LTrigger" + playerNumber) + 1);
        }
        else
        {
            pullTrigger = Input.GetAxis("LTrigger" + playerNumber);
        }

        if (pullTrigger > 0 || pushTrigger > 0)
        {
            RaycastHit tmp;
            GameObject other = GetComponent<PlayerAiming>().GetTarget(out tmp);

            if (other != null)
            {
                if (other.transform.parent != null && other.transform.parent.GetComponent<EnergyContainer>() != null)
                {
                    GetComponent<EnergyTransfer>().pushTo(other.transform.parent.GetComponent<EnergyContainer>(), pushTrigger / 5);
                    GetComponent<EnergyTransfer>().drainFrom(other.transform.parent.GetComponent<EnergyContainer>(), pullTrigger / 5);
                }
                else
                {
                    GetComponent<EnergyTransfer>().pushTo(other.GetComponent<EnergyContainer>(), pushTrigger / 5);
                    GetComponent<EnergyTransfer>().drainFrom(other.GetComponent<EnergyContainer>(), pullTrigger / 5);
                }
               
                
                GetComponent<PlayerAiming>().ActivateBezier(pullTrigger >= pushTrigger, (Mathf.Abs(pushTrigger - pullTrigger)));
            }
            else
            {
                GetComponent<PlayerAiming>().destroyParticle();
            }
        }
        else
        {
            GetComponent<PlayerAiming>().destroyParticle();
        }
    }
}
