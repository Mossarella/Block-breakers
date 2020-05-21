using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCounter : MonoBehaviour

{
    public int maxBlock;
    public int totalBlock;


    [SerializeField] Block[] numberofBlock;

    
    public SceneLoader sceneLoader;



    public void Start()
    {

       
            
        
        



    }
    public void Update()
    {



        numberofBlock = FindObjectsOfType<Block>();
            totalBlock = numberofBlock.Length;
        

        if (totalBlock<=0)
        {
            sceneLoader.loadNextScene();
        }
        
        




    }



    // Start is called before the first frame update
    

}
    // Update is called once per frame
    
