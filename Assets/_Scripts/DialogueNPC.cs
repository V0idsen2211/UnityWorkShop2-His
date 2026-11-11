using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class DialogueNPC : MonoBehaviour
{
    public float rangeToStartDialogue;
    private InputSystem_Actions inputActions;
    public  Dialogue d;
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
        
    }

    private void Update()
    {
        if (inputActions.Player.Interact.WasPressedThisFrame())
        {
            if (Vector2.Distance(PlayerMovement.Instance.transform.position, transform.position) <= rangeToStartDialogue && !startedDialogue)
            {
                Debug.Log("Starting Dialogue");
                DialogueManager.Instance.StartDialogue(d);
                startedDialogue = true;
            }
            
        }
        
        interactButton.SetActive(Vector2.Distance(PlayerMovement.Instance.transform.position, transform.position) <= rangeToStartDialogue && !startedDialogue);
    }

    void DialogueEnd(string name)
    {
        if (name == d.displayName)
        {
            obstacle.SetActive(false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangeToStartDialogue);
    }

    
    
}
