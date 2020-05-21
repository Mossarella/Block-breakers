using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    [SerializeField] AudioClip[] breakSounds;
    [SerializeField] GameObject blockEffect;

    [SerializeField] int maxHits;
    public int timesHits;

    [SerializeField] Sprite[] hitSprites;


    



    private void Start()
    {
        GetComponent<AudioSource>();
        GetComponent<GameStatus>();
        maxHits = hitSprites.Length + 1;


    }
    public void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.tag == "Ball")
        {
            
            if(this.gameObject.tag=="Block")
            {
                timesHits++;

                if (timesHits >= maxHits)
                {
                    KillBlock();
                }
                else
                {
                    ShowNextHitSprites();
                }
            }
            
            

        }

    }

    public void ShowNextHitSprites()
    {
        int spriteIndex = timesHits-1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        { Debug.LogError("Sprite is missing on block" + gameObject.name); }
    }

    public void KillBlock()
    {
        
        Destroy(this.gameObject);
        AudioSource.PlayClipAtPoint(breakSounds[0], Camera.main.transform.position);
        FindObjectOfType<GameStatus>().GetScore();
        TriggerEffect();

    }

    private void TriggerEffect()
    {

        GameObject sparkles = Instantiate(blockEffect,transform.position,transform.rotation);
        Destroy(this.gameObject, 1f);
    }
    
}
