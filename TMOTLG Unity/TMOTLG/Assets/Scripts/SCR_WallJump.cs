using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_WallJump : MonoBehaviour
{   
    private bool isWallJumping, isWallLeft, isWallRight;
    [SerializeField]
    private float xForce, yForce, wallJumpTime;
    [SerializeField]
    private float xyRadius;
    [SerializeField]
    GameObject WallDetectorLeft, WallDetectorRight;

    private Rigidbody2D wallRB;
    private SCR_Con_Player playerScript;

    private void Awake()
    {
        wallRB = this.GetComponent<Rigidbody2D>();
        playerScript = this.GetComponent<SCR_Con_Player>();
    }

    private void Update()
    {
        isWallLeft = Physics2D.OverlapCircle(WallDetectorLeft.transform.position, xyRadius);
        isWallRight = Physics2D.OverlapCircle(WallDetectorRight.transform.position, xyRadius);

        if(Input.GetKeyDown(KeyCode.Space) && isWallLeft || Input.GetKeyDown(KeyCode.Space) && isWallRight)
        {
            isWallJumping = true;
            Invoke("EndWallJump", wallJumpTime);
        }

        WallJump();

       
    }

    private void EndWallJump()
    {
        isWallJumping = false;
    }

    private void WallJump()
    {
        var xDrag = wallRB.drag;

        float h = Input.GetAxisRaw("Horizontal");

        if(isWallJumping && !playerScript.isGrounded)
        {
            //wallRB.AddForce(new Vector2(xForce * -h, yForce), ForceMode2D.Force);
            wallRB.velocity += new Vector2(xForce * -h, yForce);
            xDrag = 10f;
           
        }
    }
}
