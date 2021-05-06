using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_Manager : MonoBehaviour
{
    public GameObject[] box2;
    public GameObject map, map1;
    GameObject player;
    public Sc_playerMovement playermove;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {

        box2 = GameObject.FindGameObjectsWithTag("Box2");
        if (box2.Length == 231)
        {
            player.transform.position = new Vector3(0, 1, -11);
            StartCoroutine(moveMap());
        }
    }
    IEnumerator moveMap()
    {
        yield return new WaitForSeconds(0.2f);
        map.transform.position = new Vector3(transform.position.x + 20f, transform.position.y, transform.position.z);
        map1.transform.position = new Vector3(0, 0,0);
        for (var i = 0; i < box2.Length; i++)
        {
            Destroy(box2[i]);
        }
        playermove.GetComponent<Sc_playerMovement>().destination = player.transform.position + playermove.GetComponent<Sc_playerMovement>().nextpos;
        playermove.GetComponent<Sc_playerMovement>().direction = playermove.GetComponent<Sc_playerMovement>().nextpos;
        }
}
