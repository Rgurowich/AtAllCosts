using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contoller : MonoBehaviour {

    public float movementSpeed;
    private float valX;
    private float valY;
    private bool facingRight = true;
    private Rigidbody2D rigBody;
    private Animator animator;
    private AudioSource gameAudio;
    public AudioClip walking;
    private bool isWalking;
    private bool moving;

    //simple script for managing the plays movement

    void Start () {
        rigBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gameAudio = GetComponent<AudioSource>();
        gameAudio.clip = walking;
        moving = true;
    }
	
	void Update () {
        valX = Input.GetAxisRaw("Horizontal");
        valY = rigBody.velocity.y;
        rigBody.velocity = new Vector2(valX * movementSpeed, valY);
        if(rigBody.velocity.x != valX)
        {
            animator.SetBool("IsWalking", true);

            if(!isWalking & moving == true)
            {
                moving = false;
                StartCoroutine(PlayWalk());
            }
        }
        else
        {
            animator.SetBool("IsWalking", false);
            isWalking = false;
        }
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

    IEnumerator PlayWalk()
    {
        isWalking = true;
        gameAudio.PlayOneShot(walking);
        yield return new WaitForSeconds(gameAudio.clip.length);
        isWalking = false;
        moving = true;
    }
}
