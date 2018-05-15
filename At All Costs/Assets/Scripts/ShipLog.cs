using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipLog{

    [System.Serializable]
    public class ShipLogText
    {
        [TextArea(3, 10)]
        public string sentances;
    }
}
