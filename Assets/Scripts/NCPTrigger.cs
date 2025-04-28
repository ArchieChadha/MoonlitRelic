using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // For using UI components
using TMPro;

public class NCPTrigger : MonoBehaviour
{ 
    public GameObject dialogueBox; // The dialogue panel
    public TextMeshProUGUI dialogueText; // Text element for the dialogue (use Text instead if not using TextMeshPro)
    private bool isPlayerInRange = false;

    void Start()
    {
        dialogueBox.SetActive(false); // Hide the dialogue UI at the start
    }

    void Update()
    {
        // When the player presses 'E' and is within range of the mysterious character
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (dialogueBox.activeSelf)
            {
                CloseDialogue();
            }
            else
            {
                OpenDialogue();
            }
        }
    }

    // Show the dialogue box and set the dialogue text
    void OpenDialogue()
    {
        dialogueBox.SetActive(true);
        dialogueText.text = "Mysterious Character: The treasure is hidden deep within the canyon... but beware, the path is not what it seems.";
    }

    // Close the dialogue box
    void CloseDialogue()
    {
        dialogueBox.SetActive(false);
    }

    // Detect when the player enters the trigger zone
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure only the player can trigger this
        {
            isPlayerInRange = true;
        }
    }

    // Detect when the player leaves the trigger zone
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            CloseDialogue(); // Automatically close the dialogue when the player walks away
        }
    }
}