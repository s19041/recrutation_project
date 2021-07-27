using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vase : MonoBehaviour
{
    Animator animator;
    [SerializeField] BoxCollider2D boxcol1;
    



    private void Start()
    {
        animator = GetComponent<Animator>();

    }

    public void DestroyOnAttack()
    {
        animator.SetTrigger("Destroy");
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        boxcol1.enabled = false;

    }
}
