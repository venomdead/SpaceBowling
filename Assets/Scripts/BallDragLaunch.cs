using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Ball))]
public class BallDragLaunch : MonoBehaviour
{

    private Ball ball;
    private Vector3 initMousePos;
    private Vector3 finalMousePos;
    private float initTime;
    private float endTime;


    // Use this for initialization
    void Start()
    {

        ball = GetComponent<Ball>();
    }

    public void DragStart()
    {
        if(!ball.inPlay){
			//Capture time & position of drag start
			initMousePos = Input.mousePosition;
			initTime = Time.time;
        }
    

    }

    public void DragEnd()
    {
        if(!ball.inPlay){
			//Launche the ball
			finalMousePos = Input.mousePosition;
			endTime = Time.time;

			float dragDuration = endTime - initTime;
			float launchSpeedX = (finalMousePos.x - initMousePos.x) / dragDuration;
			float launchSpeedZ = (finalMousePos.y - initMousePos.y) / dragDuration;


			Vector3 launchVelocity = new Vector3(launchSpeedX, 0, launchSpeedZ);
			ball.Launch(launchVelocity);
        }
    }


    // Update is called once per frame
    void Update()
    {
    }

    public void MoveStart(float amount)
    {
        if ( !ball.inPlay) {

			ball.transform.Translate(amount, 0, 0);

		}
    }
}
