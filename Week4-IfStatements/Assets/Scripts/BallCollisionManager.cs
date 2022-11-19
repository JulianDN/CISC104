using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallCollisionManager : MonoBehaviour
{
    static int ballCollisionCount = 0;
    static int wallCollisionCount = 0;

    private TextMeshPro ballCountText;
    private TextMeshPro wallCountText;

   
    void Start()
    {
        GameObject ballCountGameObject = GameObject.Find("BallCollisionCount");
        GameObject wallCountGameObject = GameObject.Find("WallCollisionCount");

        ballCountText = ballCountGameObject.GetComponent<TextMeshPro>();
        wallCountText = wallCountGameObject.GetComponent<TextMeshPro>();
    }

    void Update()
    {
        ballCountText.text = "Ball Collision Count: " + ballCollisionCount;
        wallCountText.text = "Wall Collision Count: " + wallCollisionCount;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            ballCollisionCount++;

            CollideWithBall(collision.gameObject);
        }

        if (collision.gameObject.tag == "Wall")
        {
            wallCollisionCount++;
        }
    }

    public virtual void CollideWithBall(GameObject OtherBall)
    {
        Debug.Log("Base Collision Manager Function");
    }
}
