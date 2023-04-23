using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    // Start is called before the first frame update
    private static DialogueManager instance;

    [Header("Dialog UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    
    [SerializeField] InputAction continueDialog = new InputAction(type: InputActionType.Button);

    [SerializeField] GameObject NPCImg;

    private void OnEnable() {
        continueDialog.Enable();
    }

    private void OnDisable() {
        continueDialog.Disable();
    }
    private Story currentStory;

    public bool dialogueIsPlaying {get; private set;}
    private void Awake() {
        if(instance != null ) {
            Debug.LogWarning("Found more than one DialogueManager in the scene");
        }
        instance = this;
    }

    public static DialogueManager GetInstance() {
        return instance;
    }

    private void Start() {
        this.dialogueIsPlaying = false;
        this.dialoguePanel.SetActive(false);
        
    }

    private void Update() {
        if(!dialogueIsPlaying) {
            return;
        }

        if(continueDialog.WasPressedThisFrame()) {
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJson, GameObject NPCImage) {
        currentStory = new Story(inkJson.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        NPCImg = NPCImage;
        NPCImg.SetActive(true);

        ContinueStory();
    }

    private void ExitDialogueMode() {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
        NPCImg.SetActive(false);
    }

    private void ContinueStory() {

        if(currentStory.canContinue) {
            dialogueText.text = currentStory.Continue();
        } else {
            ExitDialogueMode();
        }
    }
}
