using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    [SerializeField] AudioClip[] breakSounds;

   
    

    private void Start()
    {
        GetComponent<AudioSource>();


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.tag == "Ball")
        {
            Destroy(this.gameObject);
            AudioSource.PlayClipAtPoint(breakSounds[0], Camera.main.transform.position);

        }
           
    }









}
