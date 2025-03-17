using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class LockController : MonoBehaviour
{
    public static bool canMove = false;
    public float angle;
    public float smoothness;
    public static float AngleZ = 0.0f;
    float initMousePosition = 0.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initMousePosition = Input.mousePosition.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float changed = Input.mousePosition.x/600;
        if(canMove){
            float tiltAroundZ = changed * angle;
            if(tiltAroundZ > -10) {
                float fix = tiltAroundZ * -1;
                tiltAroundZ = fix;
            }

            // Rotate the cube by converting the angles into a quaternion.
            Quaternion target = Quaternion.Euler(0, 0, tiltAroundZ);

            // Dampen towards the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * smoothness);
            AngleZ = transform.eulerAngles.z;
        }

        if(getAngleZ() <= 181.0f && getAngleZ() > 10){
            StartCoroutine(Reset());
        }
    }

    public void setMoveTrue(){
        canMove = true;
    }
    public void setMoveFalse(){
        canMove = false;
    }

    public static float getAngleZ(){
        return AngleZ;
    }

    IEnumerator Reset(){
        yield return new WaitForSecondsRealtime(1);
        transform.rotation = Quaternion.Euler(0, 0, 0);
        AngleZ = 0;
    }
}
