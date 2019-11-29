using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rollBallMenu : MonoBehaviour
{
    Rigidbody rb;
    public float rollIt;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(0, 0, rollIt);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "offGround")
        {
            rb.transform.position = new Vector3(-22.1f, 0.8f, -2.08f);
        }
    }
}
