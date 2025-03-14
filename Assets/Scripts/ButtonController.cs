using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public TextMeshProUGUI text;

    private Color32 white = new(255, 255, 255, 255);
    private Color32 grey = new(50, 50, 50, 255);
    
    public void setEnterTextColor(){
        text.color = white;
    }
    public void setExitTextColor(){
        Debug.Log("Exit");
        text.color = grey;
    }
}
