using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] int score = 0;

    [SerializeField] Text livesText;
    [SerializeField] Text scoreText;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void AddScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();
    }


    public void TakeLife()
    {
        playerLives--;
        livesText.text = playerLives.ToString();
       
    }
}
