
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

    public Vector2 GetPlayerMouseDistance()
    {
        Vector2 distance = mouseVector - playerVector;
        return distance;
    }
}
