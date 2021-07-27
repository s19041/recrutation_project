using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] int value = 1;




    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.GetComponent<Player>())
        {
            Destroy(gameObject);
            FindObjectOfType<GameSession>().AddScore(value);
        }

    }
}
