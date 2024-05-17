using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AutoGhostDialogue : MonoBehaviour
{
    public GameObject character;
    public GameObject characterCamera;
    public GameObject dialogueCamera;
    public string[] lines;
    public GameObject dialogueBox;
    public TextMeshProUGUI textComponent;
    public float textSpeed;


    private int index;


    void Start()
    {
        character.SetActive(false);
        textComponent.text = string.Empty;
        StartDialogue();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {

            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            dialogueBox.SetActive(false);
            character.SetActive(true);
            dialogueCamera.SetActive(false);
            characterCamera.SetActive(true);
        }
    }
}
