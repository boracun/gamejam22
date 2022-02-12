
using UnityEngine;

public struct MouseClickInformation
{
    public Vector2 playerVector;
    public Vector2 mouseVector;
    
    public MouseClickInformation(Vector2 playerVector, Vector2 mouseVector)
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
