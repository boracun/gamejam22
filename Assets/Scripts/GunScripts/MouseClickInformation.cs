
using UnityEngine;

public struct MouseClickInformation
{
    public Vector3 playerVector;
    public Vector3 mouseVector;
    
    public MouseClickInformation(Vector3 playerVector, Vector3 mouseVector)
    {
        this.playerVector = playerVector;
        this.mouseVector = mouseVector;
    }

    public Vector3 GetPlayerMouseDistance()
    {
        Vector3 distance = mouseVector - playerVector;
        return distance;
    }
}
