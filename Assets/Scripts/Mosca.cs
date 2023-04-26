using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Mosca : MonoBehaviour
{
    Vector3 initialPosition;
    public bool hasKey;
    public int livesCount = 3;
    public TextMeshProUGUI txtLives;
    public TextMeshProUGUI txtMonedas;
    public int countcoin;


    // Start is called before the first frame update
    void Start()
    {
        txtLives.text = livesCount.ToString();
        initialPosition = transform.position;
        txtMonedas.text = countcoin.ToString();
    }

    private void Update()
    {
        if (hasKey)
        {
            Debug.Log("Tiene la llave");
        }
        else if (countcoin == 3)
        {
            Debug.Log("Ganaste!");
            countcoin++;
        }
    }


    //Destruir la mosca si colisiona con el ventilador
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Damager"))
        {
            LoseALife();
        }

        else if (collision.gameObject.CompareTag("Coin"))
        {
            ScorePoints();
        }
                void PlayerDeath()
        {

            Destroy(gameObject);  
        }
    void LoseALife()
        {
            transform.position = initialPosition;
            livesCount--;
            txtLives.text = livesCount.ToString();
            if (livesCount == 0)
            {
                PlayerDeath();
            }
        }
    void ScorePoints()
        {       countcoin++;
                txtMonedas.text = countcoin.ToString();
                Destroy(collision.gameObject);
        }
    }
}
