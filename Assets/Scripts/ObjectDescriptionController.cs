using System;
using UnityEngine;

public class ObjectDescriptionController : MonoBehaviour
{
    public String description;
    private static String[] sentDescription;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger enter");
        DialogueController.setSencentce(description);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Trigger exit");
        DialogueController.clearSentence();
    }
}
