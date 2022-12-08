using System;
using UnityEngine;

public class RedBallCollisionManager : BallCollisionManager
{
    
    public override void CollideWithBall(GameObject OtherBall)
    {
        Debug.Log("Green Ball Collision Manager Function");

      
        OtherBall.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
    }
    
        
    
}

