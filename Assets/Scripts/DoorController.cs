using UnityEngine;

public class DoorController : MonoBehaviour
{
    public enum Direction{
        north,
        south,
        west,
        east
    }
    public Direction direction;

    public GameObject door;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UseDoor(GameObject player){
        if(direction == Direction.west){
            Vector2 pos = new Vector2(door.transform.position.x - 2.2f, door.transform.position.y);
            player.transform.position = pos;
        }else if(direction == Direction.east){
            Vector2 pos = new Vector2(door.transform.position.x + 2.2f, door.transform.position.y);
            player.transform.position = pos;
        }else if(direction == Direction.south){
            Vector2 pos = new Vector2(door.transform.position.x, door.transform.position.y - 2.2f);
            player.transform.position = pos;
        }else if(direction == Direction.north){
            Vector2 pos = new Vector2(door.transform.position.x, door.transform.position.y + 2.2f);
            player.transform.position = pos;
        }
    }
}
