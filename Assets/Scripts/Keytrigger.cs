using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Keytrigger : MonoBehaviour
{
    public GameObject youWinText; // UI Text for You Win

    private void Start()
    {
        youWinText.SetActive(false); // Hide You Win text at the start
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) // Ensure it's Alex
        {
            AlexHealth alexHealth = other.GetComponent<AlexHealth>();
            if (alexHealth != null && !alexHealth.isGameOver)
            {
                WinGame();
            }
        }
    }

    void WinGame()
    {
        youWinText.SetActive(true); // Display You Win text
        Time.timeScale = 0; //End Game
    }
    
}