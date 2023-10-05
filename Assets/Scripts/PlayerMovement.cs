using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public float jumpHeight = 7f; 
    private Rigidbody2D body; 
    private Animator anim; 
    private bool grounded; 
    private bool facingRight = true; 
    // Start is called before the first frame update
    void Awake()
    {
     body = GetComponent<Rigidbody2D>();
     anim = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        body.velocity = new Vector2(horizontalInput* speed, body.velocity.y);

        if(Input.GetKey(KeyCode.Space)&&grounded)
        {
            Jump();
        }


    }
    private void Jump(){
        body.velocity = new Vector2(body.velocity.x,jumpHeight);
        grounded = false;
    }
    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Ground")){
            grounded = true;
        }
    }
}
