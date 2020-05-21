using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameStatus : MonoBehaviour
{
    [SerializeField,Range(0.1f,10f)] float howFast=1f;

    [SerializeField] int pointPerBlock;
    [SerializeField] int currentScore = 0;

    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] bool autoPlay=true;







    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount>1)
        {
            gameObject.SetActive(false);
            Destroy(this.gameObject);
            
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }


    private void Start()
    {


        scoreText.text = currentScore.ToString();




    }

    void Update()
    {
        
        Time.timeScale = howFast;

        scoreText.text = currentScore.ToString();
        
      

    }
   
    public void GetScore()
    {

        
            currentScore = currentScore + pointPerBlock;
        

        
        

    }

    public void ResetGame()
    {
        Destroy(this.gameObject);
    }
    public bool IsAutoPlayEnabled()
    {
        return autoPlay;
    }
    
        
    
}
