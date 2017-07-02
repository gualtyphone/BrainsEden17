using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedo : MonoBehaviour {

    public void setSpedo(float percent)
    {
        switch (gameObject.name)
        {
            case "BL":
                float newRot = -45 + (percent * 0.9f);
                transform.rotation = Quaternion.Euler(0, 0, newRot);
                break;
            case "BR":
                float newRot1 = 135 - (percent * 0.9f);
                transform.rotation = Quaternion.Euler(0, 0, newRot1);
                break;
            case "TR":
                float newRot2 = 225 - (percent * 0.9f);
                transform.rotation = Quaternion.Euler(0, 0, newRot2);
                break;
            case "TL":
                float newRot3 = -135 + (percent * 0.9f);
                transform.rotation = Quaternion.Euler(0, 0, newRot3);
                break;
        }
        
        
    }
}
