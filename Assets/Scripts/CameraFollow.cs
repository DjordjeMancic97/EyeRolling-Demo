using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector3 offset;
    public GameObject player;

    void Update()
    {
        // Follow player's position and add offset to it
        transform.position = player.transform.position + offset;
    }
}
