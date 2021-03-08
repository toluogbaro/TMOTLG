using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Con_Player : MonoBehaviour
{
    private Vector2 transformPos;
    [SerializeField]
    private KeyCode jump = KeyCode.None;
    [SerializeField]
    private float moveSpeed, jumpHeight;
    private Rigidbody2D rb;

    private Vector2 moveDirection;
    private Vector2 jumpDirection;

    private bool tapJumpRequest;
   
    [HideInInspector]
    public bool isGrounded;
    [SerializeField]
    GameObject feetPos;
    [SerializeField]
    private float radius;
    [SerializeField]
    private LayerMask ground;

    

    


    private void Awake()
    {
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Confined;

        rb = this.GetComponent<Rigidbody2D>();

        transformPos = new Vector2(transform.position.x, transform.position.y);
    }

    void FixedUpdate()
    {
        Movement();
        Jumping();
    }

    void Update()
    {
        JumpRequests();

        isGrounded = Physics2D.OverlapCircle(feetPos.transform.position, radius, ground);

    



    }


    private void Movement()
    {
        float h = Input.GetAxisRaw("Horizontal");

        
        moveDirection = new Vector2(h, 0f);

        rb.velocity = new Vector2(h * moveSpeed, rb.velocity.y);


    }

    private void Jumping()
    {
        jumpDirection = new Vector2(0, 2.5f);

        
        

        if(tapJumpRequest)
        {
            

            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Force);

            tapJumpRequest = false;
            
                
        }

    



       
    }

   

    private void JumpRequests()
    {
        if (isGrounded && Input.GetKeyDown(jump))
        {
            tapJumpRequest = true;
            
        }
        
      
    }

}
