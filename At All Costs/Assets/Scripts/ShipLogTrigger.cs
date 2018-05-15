using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipLogTrigger : MonoBehaviour {
  
    void OnEnable()
    {
        FindObjectOfType<ShipLogManager>().StartLog();
    }
}
