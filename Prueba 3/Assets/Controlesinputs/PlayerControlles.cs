using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerControlles : MonoBehaviour
{
     Rigidbody2D rb;

     //public int speed; 

     Vector2 vecMove;
     public float jumpPower;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Jump (InputAction.CallbackContext value)
    {
        if (value.started){
         rb.velocity = new Vector2(rb.velocity.x, jumpPower); 

     
         }


    }

    /* public void Movement(InputAction.CallbackContext value)
    {
     vecMove = value.ReadValue<Vector2>(); 
     flip();
    }

    public void FixedUpdate()
    {
     rb.velocity = new Vector2(vecMove.x * speed, rb.velocity.y); 
     
    }*/

    void flip()
     {
     if(vecMove.x < -0.01f) transform.localScale = new Vector3(-1,1,1);
     if(vecMove.x > -0.01f) transform.localScale = new Vector3(1,1,1);
    }


}