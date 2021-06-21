using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    [SerializeField] float speed;
    int currentwaypointIndex;
    bool isFacingRight;

    Animator animator;

    private void Start()
    {
        if(waypoints[0] != null)
        transform.position = waypoints[0].position;

        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (waypoints[0] != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentwaypointIndex].position, speed * Time.deltaTime);

            if (transform.position == waypoints[currentwaypointIndex].position)
            {
                animator.SetBool("isRunning", false);

                if (currentwaypointIndex + 1 < waypoints.Length)
                {
                    currentwaypointIndex++;
                }
                else
                {
                    currentwaypointIndex = 0;
                }
            }
            else
            {
                animator.SetBool("isRunning", true);

                if (waypoints[currentwaypointIndex].position.x - transform.position.x < 0 && !isFacingRight)
                {
                    Flip();
                }
                else if (waypoints[currentwaypointIndex].position.x - transform.position.x > 0 && isFacingRight)
                {
                    Flip();
                }

            }
        }else 
            animator.SetBool("isRunning", false);
    }




    void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        isFacingRight = !isFacingRight;
    }



}
