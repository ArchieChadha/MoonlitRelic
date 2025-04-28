using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class TreasureChestTrigger : MonoBehaviour
{
    public GameObject chestMessagePanel; // Reference to the message panel
    public TextMeshProUGUI chestMessageText; // Reference to the message text
    public TextMeshProUGUI countdownText; // Reference to the countdown timer text
    private bool isPlayerInRange = false;
    private bool keyFound = false; // Track if the key is found
    public float timeToFindKey = 30f; // 30 seconds to find the key
    private float countdownTimer;
    private bool countdownActive = false;

    void Start()
    {
        chestMessagePanel.SetActive(false); // Hide the message panel initially
        countdownText.gameObject.SetActive(false); // Hide the countdown text initially
        countdownTimer = timeToFindKey; // Initialize the countdown
    }

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E) && !keyFound)
        {
            // Show the message and start the countdown when Alex interacts with the chest
            chestMessagePanel.SetActive(true);
            chestMessageText.text = "You need a Key to unlock me!";
            StartCountdown();
        }

        // Update the countdown if active
        if (countdownActive)
        {
            countdownTimer -= Time.deltaTime;
            UpdateCountdownUI();

            if (countdownTimer <= 0)
            {
                EndCountdown();
            }
        }
    }

    // Starts the countdown timer
    void StartCountdown()
    {
        countdownActive = true;
        countdownText.gameObject.SetActive(true);
    }

    // Ends the countdown and hides the UI if time runs out
    void EndCountdown()
    {
        countdownActive = false;
        countdownText.gameObject.SetActive(false); // Deactivate countdown text
        chestMessageText.text = "You lose!"; // Set the losing message
        // Optionally, keep the message panel active to show the losing message
        // Optionally, add game over logic here (e.g., restarting the game)
    }

    // Update the countdown text in the UI
    void UpdateCountdownUI()
    {
        int minutes = Mathf.FloorToInt(countdownTimer / 60);
        int seconds = Mathf.FloorToInt(countdownTimer % 60);
        countdownText.text = $"Time Left: {minutes:00}:{seconds:00}";
    }

    // Detect when Alex enters the chest's trigger zone
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true; // Set player in range
        }
    }

    // Detect when Alex leaves the chest's trigger zone
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false; // Player is no longer in range
            chestMessagePanel.SetActive(false); // Deactivate message panel
            countdownText.gameObject.SetActive(false); // Deactivate countdown text
            countdownActive = false; // Stop countdown
        }
    }
}
