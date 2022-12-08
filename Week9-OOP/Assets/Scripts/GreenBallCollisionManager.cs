using System;
using UnityEngine;

public class GreenBallCollisionManager : BallCollisionManager
{
    public AudioSource audioPlayer;

    public override void CollideWithBall(GameObject OtherBall)
    {
        Debug.Log("Green Ball Collision Manager Function");
        audioPlayer = GetComponent<AudioSource>();

        if (OtherBall.GetComponent<BlueBallCollisionManager>() != null)
        {
            Debug.Log("Green Ball Collided With Blue Ball");

            audioPlayer.Play();
        }
    }
}