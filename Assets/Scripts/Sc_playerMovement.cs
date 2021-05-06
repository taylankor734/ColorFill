using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_playerMovement : MonoBehaviour
{
    Vector3 up = Vector3.zero;
    Vector3 right =new Vector3(0,90,0);
    Vector3 down =new Vector3(0,180,0);
    Vector3 left =new Vector3(0,270,0);
    Vector3 currentdirection = Vector3.zero;

    float speed=5f;
    float rayLength = 1f;

    public GameObject box1;

    public Vector3 nextpos, destination, direction;
    public void Start()
    {
        currentdirection = up;
        nextpos = up;
        destination = transform.position;
    }
    public void Update()
    {
        Move();
    }
    public void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.W))
        {
            nextpos = Vector3.forward;
            currentdirection = up;
        }
        if (Input.GetKey(KeyCode.A) )
        {
            nextpos = Vector3.left;
            currentdirection = left;
        }
        if (Input.GetKey(KeyCode.S) )
        {
            nextpos = Vector3.back;
            currentdirection = down;
        }
        if (Input.GetKey(KeyCode.D) )
        {
            nextpos = Vector3.right;
            currentdirection = right;
        }

        if (Vector3.Distance(destination,transform.position)<=0.00001f)
        {
            transform.localEulerAngles = currentdirection;
                if (Valid())
                {
                    destination = transform.position + nextpos;
                    direction = nextpos;
                }
        }
    }
    public bool Valid()
    {
        Ray myRay = new Ray(transform.position + new Vector3(0, 0.25f,0),transform.forward);
        RaycastHit hit;

        Debug.DrawRay(myRay.origin, myRay.direction, Color.red);
        if (Physics.Raycast(myRay,out hit,rayLength))
        {
            if (hit.collider.name=="wall")
            {
                GameObject[] objects = GameObject.FindGameObjectsWithTag("Box1");
                foreach (GameObject go in objects)
                {
                    MeshRenderer[] renderers = go.GetComponentsInChildren<MeshRenderer>();
                    foreach (MeshRenderer r in renderers)
                    {
                        foreach (Material m in r.materials)
                        {
                            if (m.HasProperty("_Color"))
                                m.color = Color.blue;
                        }
                    }
                }
                return false;
            }
        }
        return true;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Box0")
        {
            StartCoroutine(box0delay(other));

        }

        if (other.gameObject.name == "Box2")
        {
            GameObject[] objects = GameObject.FindGameObjectsWithTag("Box1");
            foreach (GameObject go in objects)
            {
                MeshRenderer[] renderers = go.GetComponentsInChildren<MeshRenderer>();
                foreach (MeshRenderer r in renderers)
                {
                    foreach (Material m in r.materials)
                    {
                        if (m.HasProperty("_Color"))
                            m.color = Color.blue;
                    }
                }
            }
        } 
    }
    IEnumerator box0delay(Collider other)
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(other.gameObject);
        Instantiate(box1, new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z), Quaternion.identity);

        
    }
}
