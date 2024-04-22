using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summon : MonoBehaviour
{
    public Animator anim;
    public float timer;
    private void Start()
    {
        anim=GetComponent<Animator>();
    }
    private void Update()
    {
        timer+=Time.deltaTime;
        if (timer>3)
        {
            summon();
            anim.SetBool("Summon", true);
        }
        else
        {
            anim.SetBool("Summon", false);
        }
    }
    public void summon()
    {
        timer=0;
    }
    
}
