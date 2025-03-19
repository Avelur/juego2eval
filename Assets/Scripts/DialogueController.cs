using UnityEngine;
using TMPro;
using System;
using System.Collections;

public class DialogueController : MonoBehaviour
{
    
    public TextMeshProUGUI dialogueText;
    private static string Sentences;
    public float DialogueSpeed;
    private static bool active = false;
    private static bool textFinished = true;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && active && textFinished){
            textFinished = false;
            active = false;
            NextSentence();
        } else if(Input.GetKeyDown(KeyCode.Space) && active && !textFinished){
            dialogueText.text = "";
            textFinished = true;
        }
    }

    void NextSentence(){
        dialogueText.text = "";
        StartCoroutine(WriteSentence());
    }

    IEnumerator WriteSentence(){
        PlayerController.canMove = false;
        int Index = 0;
        foreach(char C in Sentences.ToCharArray()){
            dialogueText.text += C;
            if(Index >= 165 && (C.Equals(' ') || C.Equals('.') || C.Equals(',') || C.Equals(';') || C.Equals(':'))){
                Index = 0;
                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
                dialogueText.text = "";
            }
            yield return new WaitForSeconds(DialogueSpeed);
            Index++;
        }
        PlayerController.canMove = true;
        active = true;
    }

    public static void setSencentce(String S)
    {
        Sentences = S;
        active = true;
    }

    public static void clearSentence()
    {
        for(int i = 0; i < Sentences.Length; i++){
            Sentences = "";
        }
    }
}
