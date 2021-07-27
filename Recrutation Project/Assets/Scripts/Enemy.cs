using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health = 2;
    Animator animator;
    [SerializeField] float force = 1f;
    [SerializeField] bool isGoblin = false;




    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isGoblin)
        {
            if (collision.GetComponent<Player>())
            {
                FindObjectOfType<GameSession>().TakeLife();

                collision.GetComponent<Rigidbody2D>().AddForce(transform.up * force, ForceMode2D.Impulse);


            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        animator.SetTrigger("IsHit");
        if (health <= 0)
        {
            animator.SetTrigger("IsDying");

            
        }


    }


    public void DieAndDestroy()
    {
        Destroy(gameObject);
    }

    

    


}
