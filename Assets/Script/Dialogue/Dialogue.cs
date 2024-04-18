using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class Dialogue : MonoBehaviour
{
    public GameObject window;
    public GameObject indicator;
    public TMP_Text dialogueText;
    public List<string> dialogues;
    public float writingSpeed;
    public bool endDialogue;
    [SerializeField] private int index;
    [SerializeField] private int charIndex;
    [SerializeField] private bool started;
    [SerializeField] private bool waitForNext;
    
    private void Awake()
    {
        endDialogue = false;
        ToggleIndicator(false);
        ToggleWindow(false);
    }

    private void ToggleWindow(bool show)
    {
        window.SetActive(show);
    }
    public void ToggleIndicator(bool show)
    {
        indicator.SetActive(show);
    }

    //Start Dialogue
    public void StartDialogue()
    {
        if (started)
            return;

        started = true;
        ToggleWindow(true);
        ToggleIndicator(false);
        GetDialogue(0);
    }

    private void GetDialogue(int i)
    {
        index = i;
        charIndex = 0;
        dialogueText.text = string.Empty;
        StartCoroutine(Writing());
    }

    public void EndDialogue()
    {
        started = false;
        ToggleWindow(false);
        StopAllCoroutines();

    }
   
    IEnumerator Writing()
    {
        yield return new WaitForSeconds(writingSpeed);

        string currentDialogue = dialogues[index];
        //Write the character
        dialogueText.text += currentDialogue[charIndex];
        //increase the character index 
        charIndex++;
        //Make sure you have reached the end of the sentence
        if (charIndex < currentDialogue.Length)
        {
            //Wait x seconds 
            yield return new WaitForSeconds(writingSpeed);
            //Restart the same process
            StartCoroutine(Writing());
        }
        else
        {
            waitForNext = true;
            
            if(index==dialogues.Count-1)
            {
                endDialogue = true;
                yield return new WaitForSeconds(1f);
                EndDialogue();
            }
        }
    }

    private void Update()
    {
        if (!started)
            return;

        if (waitForNext && Input.GetKeyDown(KeyCode.E))
        {
            waitForNext = false;
            index++;

            if (index < dialogues.Count)
            {
                GetDialogue(index);
            }
            else
            {
                ToggleIndicator(true);
                EndDialogue();
            }
        }
    }


}
