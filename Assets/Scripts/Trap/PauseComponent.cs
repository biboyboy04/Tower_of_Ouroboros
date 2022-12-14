using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PauseComponent : MonoBehaviour
{
    public float animationTime;
    public float animationNumber;
    [SerializeField] private Behaviour[] components;
    private float time;
    private bool canDisable;
    public Sprite spriteStart;
    private SpriteRenderer spriteRend;


    void Start() 
    {
       // nextTimeCall = Time.time + 1f;
       canDisable = true;
       time = 0f;
       spriteRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= animationTimeToSeconds()) 
        {
            if(canDisable)
            {
                disableComponents();
                canDisable = false;
            }
            else
            {
                enableComponents();
                canDisable = true;
            }
                        
            time -= animationTimeToSeconds();

        }

    }

     public void enableComponents()
    {
        foreach (Behaviour component in components)
            component.enabled = true;
    } 


    public void disableComponents()
    {
        foreach (Behaviour component in components)
            component.enabled = false;
        spriteRend.sprite = spriteStart;
        
    } 


    private float animationTimeToSeconds()
    {
       return (animationTime * animationNumber) / 60f;
    }
}
