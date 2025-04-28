using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AlexHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public TextMeshProUGUI gameOverText; // UI text for Game Over
    public Slider healthBar; // Health bar UI to display Alex's health
    public bool isGameOver = false;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.value = currentHealth;
        gameOverText.gameObject.SetActive(false); // Hide Game Over text at the start
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.value = currentHealth;

        if (currentHealth <= 0 && !isGameOver)
        {
            GameOver("You Lost your life. Game Over!");
        }
    }

    void GameOver(string message)
    {
        isGameOver = true;
        gameOverText.text = message;
        gameOverText.gameObject.SetActive(true);
        healthBar.gameObject.SetActive(false);
        Time.timeScale = 0; //Pause game
       
    }
}