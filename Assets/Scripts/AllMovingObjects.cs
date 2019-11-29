using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllMovingObjects : MonoBehaviour
{
    public float speed;
    float currentX, currentY, currentZ;

    // Closing gate obstacle
    public float rightGateStartingPoint = -6f;
    public float rightGateEndingPoint = -2.8f;
    public float leftGateStartingPoint = 6f;
    public float leftGateEndingPoint = 2.8f;
    public Vector3 leftGatePointA, rightGatePointA, leftGatePointB, rightGatePointB;

    // ScaleZ obstacle
    public float scaleZStartingPoint = 8f;
    public float scaleZEndingPoint = 2f;
    public Vector3 scaleZPointA, scaleZPointB;

    // UpDown obstacle
    public float upDownStartingPoint = 8f;
    public float upDownEndingPoint = 2f;
    public Vector3 upDownPointA, upDownPointB;

    // LeftRightBlock obstacle
    public float leftRightBlockStartingPoint = 8f;
    public float leftRightBlockEndingPoint = -8f;
    public Vector3 leftRightBlockPointA, leftRightBlockPointB;

    // RiverBoat obstacle
    public float riverBoatStartingPoint = -16.5f;
    public float riverBoatEndingPoint = 9f;
    public Vector3 riverBoatPointA, riverBoatPointB;

    // Rotating gate
    // this obstacle is only rotating around its Y

    // Right Smashers obstacle
    public float rightSmasherStartingPoint = 20f;
    public float rightSmasherEndingPoint = 94f;
    public Vector3 rightSmasherPointA, rightSmasherPointB;
    
    // Left Smasher obstacle
    public float leftSmasherStartingPoint = -20f;
    public float leftSmasherEndingPoint = -94f;
    public Vector3 leftSmasherPointA, leftSmasherPointB;


    void Start()
    {
        // Storing current position so its not stuck at 0
        currentX = transform.position.x;
        currentY = transform.position.y;
        currentZ = transform.position.z;

        switch (gameObject.name)
        {
            case "rightGate":
                rightGatePointA = new Vector3(currentX, currentY, rightGateStartingPoint);
                rightGatePointB = new Vector3(currentX, currentY, rightGateEndingPoint);
                break;
            case "leftGate":
                leftGatePointA = new Vector3(currentX, currentY, leftGateStartingPoint);
                leftGatePointB = new Vector3(currentX, currentY, leftGateEndingPoint);
                break;
            case "scaleZ":
                scaleZPointA = new Vector3(transform.localScale.x, transform.localScale.y, scaleZStartingPoint);
                scaleZPointB = new Vector3(transform.localScale.x, transform.localScale.y, scaleZEndingPoint);
                break;
            case "upDown":
                upDownPointA = new Vector3(currentX, upDownStartingPoint, currentZ);
                upDownPointB = new Vector3(currentX, upDownEndingPoint, currentZ);
                break;
            case "leftRightBlock":
                leftRightBlockPointA = new Vector3(currentX, currentY, leftRightBlockStartingPoint);
                leftRightBlockPointB = new Vector3(currentX, currentY, leftRightBlockEndingPoint);
                break;
            case "riverBoat":
                riverBoatPointA = new Vector3(riverBoatStartingPoint, currentY, currentZ);
                riverBoatPointB = new Vector3(riverBoatEndingPoint, currentY, currentZ);
                break;
            case "leftSmasher":
                leftSmasherPointA = new Vector3(leftSmasherStartingPoint, currentY, currentZ);
                leftSmasherPointB = new Vector3(leftSmasherEndingPoint, currentX, currentZ);
                break;
            case "rightSmasher":
                rightSmasherPointA = new Vector3(rightSmasherStartingPoint, currentY, currentZ);
                rightSmasherPointB = new Vector3(rightSmasherEndingPoint, currentX, currentZ);
                break;
        }
        
    }

   
    void Update()
    {
        switch (gameObject.name)
        {
            case "rightGate":
                speed = 2f;
                float time = Mathf.PingPong(Time.time * speed, 1);
                transform.position = Vector3.Lerp(rightGatePointA, rightGatePointB, time);
                break;
            case "leftGate":
                speed = 2f;
                time = Mathf.PingPong(Time.time * speed, 1);
                transform.position = Vector3.Lerp(leftGatePointA, leftGatePointB, time);
                break;
            case "scaleZ":
                speed = 1.5f;
                time = Mathf.PingPong(Time.time * speed, 1);
                transform.localScale = Vector3.Lerp(scaleZPointA, scaleZPointB, time);
                break;
            case "upDown":
                speed = 2f;
                time = Mathf.PingPong(Time.time * speed, 1);
                transform.position = Vector3.Lerp(upDownPointA, upDownPointB, time);
                break;
            case "leftRightBlock":
                speed = 0.7f;
                time = Mathf.PingPong(Time.time * speed, 1);
                transform.position = Vector3.Lerp(leftRightBlockPointA, leftRightBlockPointB, time);
                break;
            case "riverBoat":
                speed = 0.5f;
                time = Mathf.PingPong(Time.time * speed, 1);
                transform.position = Vector3.Lerp(riverBoatPointA, riverBoatPointB, time);
                break;
            case "rotatingGate":
                speed = 100f;
                transform.Rotate(0, speed * Time.deltaTime, 0, Space.Self);
                break;
            case "leftSmasher":
                speed = 2f;
                time = Mathf.PingPong(Time.time * speed, 1);
                transform.rotation = Quaternion.Euler(Vector3.Lerp(leftSmasherPointA, leftSmasherPointB, time));
                break;
            case "rightSmasher":
                speed = 2f;
                time = Mathf.PingPong(Time.time * speed, 1);
                transform.rotation = Quaternion.Euler(Vector3.Lerp(rightSmasherPointA, rightSmasherPointB, time));
                break;
        }
    }
}
