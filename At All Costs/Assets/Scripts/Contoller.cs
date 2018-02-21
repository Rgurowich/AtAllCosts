using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contoller : MonoBehaviour {

    public float movementSpeed;
    float valX;
    float valY;
    bool facingRight = true;
    Rigidbody2D rigBody;

	void Start () {
        rigBody = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        valX = Input.GetAxisRaw("Horizontal");
        valY = rigBody.velocity.y;
        rigBody.velocity = new Vector2(valX * movementSpeed, valY);
	}

    void LateUpdate()
    {
        Vector3 localScale = transform.localScale;
        if (valX > 0)
        {
            facingRight = true;
        } else if (valX < 0)
        {
            facingRight = false;
        }
        if(((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0))){
            localScale.x *= -1;
        }

        transform.localScale = localScale;
    }
}
