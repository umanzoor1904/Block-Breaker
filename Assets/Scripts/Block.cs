using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    [SerializeField] GameObject vfx;
    [SerializeField] Sprite[] hitSprites;

    Level level;
    GameStatus status;

    [SerializeField] int timesHit = 0;

    private void Start()
    {
        CountBreakableBlock();
    }

    private void CountBreakableBlock()
    {
        level = FindObjectOfType<Level>();
        status = FindObjectOfType<GameStatus>();
        if (tag == "Breakable")
            level.countBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            DestroyBlock();

        }
    }

    private void DestroyBlock()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            Destroy(gameObject);
            level.destroyBlock();
            status.AddToScore();
            TriggerVFX();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int i = timesHit - 1;
        if (hitSprites[i] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[i];
        }
        else
        {
            Debug.LogError("Block sprite missing!" + gameObject.name);
        }
    }

    private void TriggerVFX()
    {
        GameObject sparkels = Instantiate(vfx, transform.position, transform.rotation);
        Destroy(sparkels, 2f);
    }
}
