using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController3 : MonoBehaviour
{

    private Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    
    private float horizontal;
    public float speed = 5f;
    public float jumpingPower = 5f;
    private bool isFacingRight = true;

    Vector2 vecMove;
     

    //girar y horizontal



    // Start is called before the first frame update
    void Start()
    {
        //anexo giro, movimiento y salto
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update(){

        
    }

    public void Jump(InputAction.CallbackContext value)
    {
        if (value.started)
         {
          rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

    
         }

    }

    public void Movement(InputAction.CallbackContext value)
    {
        vecMove = value.ReadValue<Vector2>();

    }


    public void FixedUpdate()
    {
        rb.velocity = new Vector2(vecMove.x*speed, rb.velocity.y);
    }


   

    private void Flip()
     {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

}
