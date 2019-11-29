using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    Rigidbody rb;
    public float jumpForce = 3f;
    bool jumpLimit = false; // change to int for multiple jumping at once

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        jumpLimit = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpLimit)
        {
            rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
            jumpLimit = false;
        }
    }
}
