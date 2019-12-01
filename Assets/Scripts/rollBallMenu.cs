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
        
        rb.AddForce(-rollIt, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "offGround")
        {
            rb.velocity = Vector3.zero;
            rb.transform.position = new Vector3(2.1f, 0.8f, -22.1f);
        }
    }
}
