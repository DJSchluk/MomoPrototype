using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour {

    public float speed;
    public float jump;
    public bool isGrounded = true;
    public bool isDead = false;
    private Vector2 movement;
    private Rigidbody2D rg;

	// Use this for initialization
	void Start () {
        rg = GetComponent<Rigidbody2D>();
        speed = 10f;
        jump = 300f;
		
	}
	
	// Update is called once per frame
	void Update () {
        if ((Input.GetKeyDown(KeyCode.Space)) && isGrounded == true)
        {
            rg.AddForce(new Vector2(0, jump));
            isGrounded = false;
        }
        float inputX = Input.GetAxisRaw("Horizontal");
        movement = new Vector2(speed * inputX, 0);
        rg.AddForce(movement);
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isDead = true;
    }

}
