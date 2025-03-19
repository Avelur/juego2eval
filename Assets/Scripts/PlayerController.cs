using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject PLAYER;
    public InputAction moveUp;
    public InputAction moveDown;
    public InputAction moveLeft;
    public InputAction moveRight;
    public InputAction exit;
    private static GameObject lockScreen;
    private static GameObject inv1;
    public AudioSource audioSource;
    
    public InputAction use;
    public static InputAction useInternal;
    public float speed = 0.0f;
    public Animator animator;
    private float direction = 0.0f;
    public static bool canMove = true;
    private static bool openedLock = false;
    private DoorController doorController;
    private GameObject key;
    public static bool HaveKey = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveUp.Enable();
        moveDown.Enable();
        moveLeft.Enable();
        moveRight.Enable(); 
        exit.Enable();
        use.Enable();
        lockScreen = GameObject.Find("LockScreen");
        inv1 = GameObject.Find("inv1");
        lockScreen.SetActive(false);
        inv1.SetActive(false);
        useInternal = use;
        useInternal.Enable();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(Input.mousePosition);
        if(canMove == true){
            animator.SetFloat("changeXright", 0);
            animator.SetFloat("changeYright", 0);
            Vector2 position = transform.position;
            float moveX = position.x;
            float moveY = position.y;
                if(moveUp.IsPressed()){
                position.y += 1.0f * Time.deltaTime * speed;
                direction = 1.0f;
            }
            if(moveDown.IsPressed()){
                position.y -= 1.0f * Time.deltaTime * speed;
                direction = 0.0f;
            }
            if(moveLeft.IsPressed()){
                position.x -= 1.0f * Time.deltaTime * speed;
                direction = 4.0f;
            }
            if(moveRight.IsPressed()){
                position.x += 1.0f * Time.deltaTime * speed;
                direction = 3.0f;
            }
            if(exit.IsPressed()){
                SceneManager.LoadScene("MainMenu");
            }
            float checkMoveX = position.x - moveX;
            float checkMoveY = position.y - moveY;
            animator.SetFloat("direction", direction);
            if(checkMoveX > 0){
                animator.SetFloat("changeXright", 1);
            }
            if(checkMoveX < 0){
                animator.SetFloat("changeXright", -1);
            }
            if(checkMoveY > 0){
                animator.SetFloat("changeYright", 1);
            }
            if(checkMoveY < 0){
                animator.SetFloat("changeYright", -1);
            }
            transform.position = position;
        } else {
            animator.SetFloat("changeXright", 0);
            animator.SetFloat("changeYright", 0);
        }

        if(LockController.getAngleZ() <= 181.0f && LockController.getAngleZ() > 179 && openedLock){
            LockController.canMove = false;
            StartCoroutine(openDoor());
        }
    }

    IEnumerator openDoor(){
        yield return new WaitForSecondsRealtime(1);
        lockScreen.SetActive(false);
        openedLock = false;
        doorController.UseDoor(PLAYER);
        canMove = true;
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("lockedDoor"))
        {
            if(use.IsPressed()){
                doorController = collision.GetComponent<DoorController>();
                openedLock = true;
                lockScreen.SetActive(true);
                canMove = false;
            }
        }
        if(collision.CompareTag("key")){
            audioSource.Play(0);
            HaveKey = true;
            inv1.SetActive(true);
            key = collision.gameObject;
            Destroy(key);
        }
    }
}
