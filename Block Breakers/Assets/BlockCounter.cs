using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCounter : MonoBehaviour

{
    
    [SerializeField] int totalBlock;
    [SerializeField] Block[] numberofBlock;

    


    public void Start()
    {
        numberofBlock=FindObjectsOfType<Block>();
        totalBlock = numberofBlock.Length;




    }

    // Start is called before the first frame update
    

}
    // Update is called once per frame
    
