using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_Box1 : MonoBehaviour
{
    public void Update()
    {
        if(gameObject.GetComponent<MeshRenderer>().material.color==Color.blue)
        {
            gameObject.name="Box2";
            gameObject.tag = "Box2";
        }
    }
}
