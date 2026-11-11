using System;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Queue<string> sentences;
    public Animator anim;
    public TextMeshProUGUI nameText, dialogueText;
    public static Action<string> OnDialogueEnd;
    private Dialogue currentDialogue;
    public static DialogueManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        currentDialogue = dialogue;
        anim.CrossFade("Start", 0f);
        nameText.text = dialogue.displayName;
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
        
    }

    public void DisplayNextSentence()
    {
        
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeEffect(sentence));
    }

    IEnumerator TypeEffect(string sentence)
    {
        string textToType = "";
        foreach (char a in sentence.ToCharArray())
        {
            textToType += a;
            dialogueText.text = textToType;
            yield return new WaitForSeconds(0.05f);
        }
        
    }

    public void EndDialogue()
    {
        OnDialogueEnd?.Invoke(currentDialogue.displayName);
        anim.CrossFade("End", 0f);
        currentDialogue = null;
    }
}

[System.Serializable]
public class Dialogue
{
    public string displayName;
    [TextArea(3, 5)]
    public string[] sentences;
}