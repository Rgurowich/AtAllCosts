using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroTrigger : MonoBehaviour {

    void OnEnable()
    {
        FindObjectOfType<ShipLogManager>().StartIntro();
    }
}
