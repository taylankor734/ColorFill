using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sc_obstacle : MonoBehaviour
{
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Box2")
        {
            Destroy(this.gameObject);
        }
        if (other.gameObject.name== "Box1(Clone)")
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
    
}
