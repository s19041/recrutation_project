using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] int value = 1;




    private void OnTriggerEnter2D(Collider2D collision)
    {
        //add score to UI

        Destroy(gameObject);
        FindObjectOfType<GameSession>().AddScore(value);

    }
}
