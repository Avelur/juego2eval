using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoorControler : MonoBehaviour
{
    public String exitScene;

    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && PlayerController.HaveKey && PlayerController.useInternal.IsPressed()){
            SceneManager.LoadScene(exitScene);
        }
        else{
            DialogueController.setSencentce("I NEED the key...");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        DialogueController.clearSentence();
    }
}
