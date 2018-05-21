using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroTrigger : MonoBehaviour {

    //trigger for intro
    void OnEnable()
    {
        FindObjectOfType<ShipLogManager>().StartIntro();
    }
}
