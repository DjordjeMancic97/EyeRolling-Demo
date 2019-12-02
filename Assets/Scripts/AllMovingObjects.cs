using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllMovingObjects : MonoBehaviour
{
    public float speed;
    float currentX, currentY, currentZ;

    // Closing gate obstacle
    float rightGateStartingPoint = 2.4f;
    float rightGateEndingPoint = 6f;
    float leftGateStartingPoint = -2.4f;
    float leftGateEndingPoint = -6f;
    Vector3 leftGatePointA, rightGatePointA, leftGatePointB, rightGatePointB;

    // ScaleX obstacle
    float scaleXStartingPoint = 8f;
    float scaleXEndingPoint = 2f;
    Vector3 scaleXPointA, scaleXPointB;

    // UpDown obstacle
    float upDownStartingPoint = 8f;
    float upDownEndingPoint = 2f;
    Vector3 upDownPointA, upDownPointB;

    // LeftRightBlock obstacle
    float leftRightBlockStartingPoint = 8f;
    float leftRightBlockEndingPoint = -8f;
    Vector3 leftRightBlockPointA, leftRightBlockPointB;

    // RiverBoat obstacle
    float riverBoatStartingPoint = -16.5f;
    float riverBoatEndingPoint = 9f;
    Vector3 riverBoatPointA, riverBoatPointB;

    // Rotating gate
    // this obstacle is only rotating around its Y

    // Right Smashers obstacle
    float rightSmasherStartingPoint = 20f;
    float rightSmasherEndingPoint = 94f;
    Vector3 rightSmasherPointA, rightSmasherPointB;
    
    // Left Smasher obstacle
    float leftSmasherStartingPoint = -20f;
    float leftSmasherEndingPoint = -94f;
    Vector3 leftSmasherPointA, leftSmasherPointB;


    void Start()
    {
        // Storing current position so its not stuck at 0
        currentX = transform.position.x;
        currentY = transform.position.y;
        currentZ = transform.position.z;

        switch (gameObject.name)
        {
            case "rightGate":
                rightGatePointA = new Vector3(rightGateStartingPoint, currentY, currentZ);
                rightGatePointB = new Vector3(rightGateEndingPoint, currentY, currentZ);
                break;
            case "leftGate":
                leftGatePointA = new Vector3(leftGateStartingPoint, currentY, currentZ);
                leftGatePointB = new Vector3(leftGateEndingPoint, currentY, currentZ);
                break;
            case "scaleX":
                scaleXPointA = new Vector3(transform.localScale.x, transform.localScale.y, scaleXStartingPoint);
                scaleXPointB = new Vector3(transform.localScale.x, transform.localScale.y, scaleXEndingPoint);
                break;
            case "upDown":
                upDownPointA = new Vector3(currentX, upDownStartingPoint, currentZ);
                upDownPointB = new Vector3(currentX, upDownEndingPoint, currentZ);
                break;
            case "leftRightBlock":
                leftRightBlockPointA = new Vector3(leftRightBlockStartingPoint, currentY, currentZ);
                leftRightBlockPointB = new Vector3(leftRightBlockEndingPoint, currentY, currentZ);
                break;
            case "riverBoat":
                riverBoatPointA = new Vector3(currentX, currentY, riverBoatStartingPoint);
                riverBoatPointB = new Vector3(currentX, currentY, riverBoatEndingPoint);
                break;
            case "leftSmasher":
                leftSmasherPointA = new Vector3(currentX, currentY, leftSmasherStartingPoint);
                leftSmasherPointB = new Vector3(currentX, currentY, leftSmasherEndingPoint);
                break;
            case "rightSmasher":
                rightSmasherPointA = new Vector3(currentX, currentY, rightSmasherStartingPoint);
                rightSmasherPointB = new Vector3(currentX, currentY, rightSmasherEndingPoint);
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
            case "scaleX":
                speed = 1.5f;
                time = Mathf.PingPong(Time.time * speed, 1);
                transform.localScale = Vector3.Lerp(scaleXPointA, scaleXPointB, time);
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
