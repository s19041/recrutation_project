using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigidbody2D;

    [SerializeField] float speed = 5f;
    [SerializeField] float jumpforce = 5f;
    bool isFacingRight = true;

    bool isOnGround;
    [SerializeField] float checkRadius;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();

    }


    private void Move()
    {
        float input = Input.GetAxis("Horizontal");
        rigidbody2D.velocity = new Vector2(input * speed, rigidbody2D.velocity.y);

        if (input > 0 && isFacingRight == false)
        {
            Flip();
        }
        else if (input < 0 && isFacingRight == true)
        {
            Flip();
        }



    }

    void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        isFacingRight = !isFacingRight;
    }


    private void Jump()
    {

        isOnGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);





        if (Input.GetKeyDown(KeyCode.W) && isOnGround)
        {
            Vector2 jumpVelocity = new Vector2(0f, jumpforce);
            rigidbody2D.velocity += jumpVelocity;
        }
    }
}
