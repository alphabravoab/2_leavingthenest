using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdfly : MonoBehaviour {

    [SerializeField] float turningspeed = 10f;
    [SerializeField] float forwardspeed = 10f;
    [SerializeField] float upspeed = 10f;
    Rigidbody rigidBody;
    AudioSource m_MyAudioSource;

    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody>();
        m_MyAudioSource = GetComponent<AudioSource>();
        
    }
	
	// Update is called once per frame
	void Update () {
        thrust();
        steering();
        turn();
	}



    private void thrust()
    {

        float forwardThisFrame = forwardspeed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up);
            rigidBody.AddForce(-Vector3.forward * forwardThisFrame);
            soundOfFlapping();
        }
    }

    private void soundOfFlapping()
    {
        if (!m_MyAudioSource.isPlaying)
        {
            m_MyAudioSource.Play();
        }
    }

    private void steering()
    {
  
        float rotationthisFrame = turningspeed * Time.deltaTime;
        float UpthisFrame = upspeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotationthisFrame);
            transform.Rotate(Vector3.up * UpthisFrame);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationthisFrame);
            transform.Rotate(-Vector3.up * rotationthisFrame);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                print("ok");
                break;
            case "Food":
                print("Food");
                break;
            default:
                print("death");
                break;

        }
    }
    private void turn()
    {
        rigidBody.freezeRotation = true;
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector2.left);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(-Vector2.left);
        }
        rigidBody.freezeRotation = false;
    }

}
