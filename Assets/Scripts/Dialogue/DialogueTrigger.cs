using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    // [Header("Emote Animator")]
    // [SerializeField] private Animator emoteAnimator;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

        [SerializeField] private GameObject NPCImg;


    private bool playerInRange;
    private bool hasSpoken;

    private void Awake() 
    {
        hasSpoken = false;
        playerInRange = false;
        this.NPCImg.SetActive(false);
    }

    private void Update() 
    {
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying) 
        {
            if(!hasSpoken) {

                DialogueManager.GetInstance().EnterDialogueMode(inkJSON, NPCImg);
                hasSpoken = true;
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.gameObject.tag == "Player" && !hasSpoken)
        {
            Debug.Log("Got Impact");
            playerInRange = true;
            // hasSpoken = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider) 
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = false;
            hasSpoken = true;
        }
    }
}
