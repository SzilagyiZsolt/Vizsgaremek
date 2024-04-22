using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    public float length;
    public float startPosition=0;
    public GameObject can1;
    public float parallaxEffect;
    void Start()
    {
        length=20;
    }

    void Update()
    {
        float temp = can1.transform.position.x*(1-parallaxEffect);
        float dist = can1.transform.position.x * parallaxEffect;
        transform.position= new Vector3(startPosition+dist, transform.position.y, transform.position.z);

        if (temp > startPosition+length)
        {
            startPosition+=length;
        }
        else if(temp < startPosition-length)
        {
            startPosition-=length;
        }
    }
}
