using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public InputAction moveUp;
    public InputAction moveDown;
    public InputAction moveLeft;
    public InputAction moveRight;
    public InputAction exit;
    public float speed = 0.0f;
    public Animator animator;
    private float direction = 0.0f;
    public static bool canMove = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveUp.Enable();
        moveDown.Enable();
        moveLeft.Enable();
        moveRight.Enable(); 
        exit.Enable();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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
    }
}
