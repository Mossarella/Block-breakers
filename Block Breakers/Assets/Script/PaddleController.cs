using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    // Start is called before the first frame update

    
    private Rigidbody2D rb;
    private Vector3 mousePos;
    private Vector2 direction;
    [SerializeField] float moveSpeed;

    public Ball ball;

    public GameStatus theGameStatus;

    

    



    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

        theGameStatus=FindObjectOfType<GameStatus>();


        ball = FindObjectOfType<Ball>();

        

    }

    // Update is called once per frame
    void Update()
    { 
        


        //float mousePosInUnits= Input.mousePosition.x / Screen.width*screenWidthInUnits ;
        //Vector3 paddlePos = new Vector3(mousePosInUnits, transform.position.y,mousePosInZ);

        //transform.position = paddlePos;

        
        
       

        
        
         
        rb.velocity = new Vector2(direction.x * moveSpeed, direction.y * 0);

        PlayAuto();





    }
    private void PlayAuto()
    {
        
       

        if (theGameStatus.IsAutoPlayEnabled())
        {
            this.transform.position=new Vector3(ball.transform.position.x, transform.position.y,transform.position.z);
        }
        else
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = (mousePos - transform.position).normalized;

        }


    }
}
