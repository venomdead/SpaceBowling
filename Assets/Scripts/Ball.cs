using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public bool inPlay = false;
	public Vector3 launchVelocity;


    private Rigidbody ballRigidBody;
    private AudioSource audioSource;
    private Vector3 ballPos;
    private Vector3 cameraPos;


	// Use this for initialization
	void Start () {

        ballPos = transform.position;
        print(ballPos);

        ballRigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

        ballRigidBody.useGravity = false;

	}
	
	// Update is called once per frame
	void Update () {

		
	}

    public void Launch(Vector3 velocity){

        ballRigidBody.useGravity = true;
        ballRigidBody.velocity = velocity;


	}

    private void OnCollisionEnter(Collision collision)
    {
        
        audioSource.Play();
    }

    public void Reset()
    {
        inPlay = false;
        transform.position = ballPos;
        ballRigidBody.useGravity = false;
        ballRigidBody.velocity = Vector3.zero;
        ballRigidBody.angularVelocity = Vector3.zero;
        transform.rotation = Quaternion.identity;
    }

}
