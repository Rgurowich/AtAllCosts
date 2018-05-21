using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipLog{

    //A class made to create ship log objects that are then used to display in the ship log//

    [System.Serializable]
    public class ShipLogText
    {
        [TextArea(3, 10)]
        public string sentances;
    }
}
