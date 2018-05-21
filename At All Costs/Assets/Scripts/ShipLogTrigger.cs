using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipLogTrigger : MonoBehaviour {
  
    //trigger for shiplog sequence
    void OnEnable()
    {
        FindObjectOfType<ShipLogManager>().StartLog();
    }
}
