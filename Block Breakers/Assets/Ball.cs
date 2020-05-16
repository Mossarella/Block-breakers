using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] PaddleController paddle1;
    Rigidbody2D rb;
    AudioSource myAudiosource;

    [SerializeField] float launchRandomValueXMin;
    [SerializeField] float launchRandomValueXMax;
    [SerializeField] float launchRandomValueYMin;
    [SerializeField] float launchRandomValueYMax;

    [SerializeField] float speed;

    private bool hasStarted;

    //state
    private Vector3 paddleToBallVector;

    [SerializeField] AudioClip[] ballSounds;
    
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        rb = GetComponent<Rigidbody2D>();
        myAudiosource = GetComponent<AudioSource>();
        hasStarted = false;
    }

    
    void Update()
    {
        rb.velocity = speed * (rb.velocity.normalized);

        if (hasStarted == false)
        {
            LockBallToPaddle();
            Launch();
        }
        
    }

    private void Launch()
    {
       if(Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            rb.velocity = new Vector2(Random.Range(launchRandomValueXMin, launchRandomValueXMax), Random.Range(launchRandomValueYMin, launchRandomValueYMax));
        }
    }

    private void LockBallToPaddle()
    {
        
        Vector3 paddlePos = new Vector3(paddle1.transform.position.x, paddle1.transform.position.y, paddle1.transform.position.z);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted == true)
        {
            AudioClip clip = ballSounds[Random.Range(0,ballSounds.Length)];
            
            myAudiosource.PlayOneShot(clip);
        }

    }
}
