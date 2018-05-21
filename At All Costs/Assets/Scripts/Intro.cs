using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour {

    //Script for managering the intro animiations//

    public Animator lastShip;
    public GameObject ship;
    public GameObject intro;
    public bool introPlayed;

    void Start () {
        intro.SetActive(true);
        lastShip = ship.GetComponent<Animator>();
        introPlayed = false;
    }
	
	void Update () {
        if(introPlayed == false)
        {
            GameObject.Find("Hayden").GetComponent<Contoller>().enabled = false;
            if (lastShip.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !lastShip.IsInTransition(0))
            {
                intro.SetActive(false);
                introPlayed = true;
                GameObject.Find("Hayden").GetComponent<Contoller>().enabled = true;
            }
        }		
	}
}
