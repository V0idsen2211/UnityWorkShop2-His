using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class DialogueNPC : MonoBehaviour
{
    public float rangeToStartDialogue;
    private InputSystem_Actions inputActions;
    public  Dialogue dialogue;
    private bool startedDialogue = false;
    public GameObject interactButton;
    public GameObject obstacle;
    private void OnEnable()
    {
        DialogueManager.OnDialogueEnd += DialogueEnd;
    }

    private void Start()
    {
        inputActions = new InputSystem_Actions();
        inputActions.Player.Enable();
        inputActions.Player.Interact.performed += StartDialogue;
    }

    private void Update()
    {
        
        interactButton.SetActive(Vector2.Distance(PlayerMovement.Instance.transform.position, transform.position) <= rangeToStartDialogue && !startedDialogue);
    }

    void DialogueEnd(string name)
    {
        if (name == dialogue.displayName)
        {
            obstacle.SetActive(false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangeToStartDialogue);
    }

    void StartDialogue(InputAction.CallbackContext context)
    {
        if (Vector2.Distance(PlayerMovement.Instance.transform.position, transform.position) <= rangeToStartDialogue && !startedDialogue)
        {
            Debug.Log("Starting Dialogue");
            DialogueManager.Instance.StartDialogue(dialogue);
            startedDialogue = true;
            
        }
    }
    
}
