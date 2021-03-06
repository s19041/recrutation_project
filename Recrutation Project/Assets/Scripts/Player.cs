using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    Animator animator;

    [SerializeField] float speed = 5f;
    [SerializeField] float jumpforce = 5f;
    bool isFacingRight = true;
    bool isDead = false;

    bool isOnGround;
    [SerializeField] float checkRadius;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;

    [SerializeField] float timeBetweenAttacks;
    float nextAttackTime;

    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRange;
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] int damage = 1;

    [SerializeField] GameObject hitVFX;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        if (isDead) return;
        

            Move();
            Jump();
            Attack();
        

        

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

        if (input != 0)
        {
            animator.SetBool("isRunning", true);

        }
        else
        {
            animator.SetBool("isRunning", false);

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


        if (isOnGround == true)
        {
            animator.SetBool("isJumping", false);

        }
        else
        {
            animator.SetBool("isJumping", true);

        }



    }


    private void Attack()
    {
        if (Time.time > nextAttackTime)
        {
            if (Input.GetKey(KeyCode.Space))
            {

                animator.SetTrigger("isAttacking");
                nextAttackTime = Time.time + timeBetweenAttacks;

                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
                foreach (Collider2D col in enemiesToDamage)
                {
                    if(col.GetComponent<Vase>())
                        col.GetComponent<Vase>().DestroyOnAttack();
                    else
                    col.GetComponent<Enemy>().TakeDamage(damage);

                    Instantiate(hitVFX, new Vector3(col.transform.position.x,col.transform.position.y), Quaternion.identity);

                    
                }
            }
        }
    }

    public void Die()
    {
        isDead = true;
        animator.SetTrigger("IsDead");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public bool IsTurnedRight()
    {
        return isFacingRight;
    }

    public void DieAndDestroy()
    {
        Destroy(gameObject);
    }



}
