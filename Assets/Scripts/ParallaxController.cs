using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    private float length, startpos; 
    public GameObject cam;
    public float parallaxEffect;
    public float posY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float dist = cam.transform.position.x * parallaxEffect;

        transform.position = new Vector3(startpos + dist, cam.transform.position.y + posY, transform.position.z);
    }
}
