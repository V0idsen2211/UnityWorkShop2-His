using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class DialogueNPC : MonoBehaviour
{
    public float rangeToStartDialogue;
    private InputSystem_Actions inputActions;
    public  Dialogue startingDialogue, regularDialogue;
    private bool startedDialogue = false;
    public GameObject interactButton;
    public GameObject obstacle;
    private bool finishedStartingDialogue = false;
    public GameObject explosionSound;
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
            if (Vector2.Distance(PlayerMovement.Instance.transform.position, transform.position) <= rangeToStartDialogue && !startedDialogue && !finishedStartingDialogue)
            {
                Debug.Log("Starting Dialogue");
                DialogueManager.Instance.StartDialogue(startingDialogue);
                startedDialogue = true;
            }else if (Vector2.Distance(PlayerMovement.Instance.transform.position, transform.position) <= rangeToStartDialogue && !startedDialogue && finishedStartingDialogue)
            {
                DialogueManager.Instance.StartDialogue(regularDialogue);
                startedDialogue = true;
            }
            
        }
        
        interactButton.SetActive(Vector2.Distance(PlayerMovement.Instance.transform.position, transform.position) <= rangeToStartDialogue && !startedDialogue);
    }

    void DialogueEnd(string name)
    {
        if (name == startingDialogue.displayName)
        {
            startedDialogue = false;
            finishedStartingDialogue = true;
            Instantiate(explosionSound, obstacle.transform.position, Quaternion.identity);
            Destroy(obstacle);
            
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangeToStartDialogue);
    }

    
    
}
