using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeController : MonoBehaviour
{
    bool isCollide;
    Transform gameObjectToLead;
    // Start is called before the first frame update
    void Start()
    {
        isCollide = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCollide)
        {
            transform.position+= new Vector3(0, 0,  -gameObjectToLead.GetComponent<PlayerController>().ballSpeed *Time.deltaTime);
            transform.position = new Vector3(gameObjectToLead.GetComponent<PlayerController>().targetX, transform.position.y,transform.position.z);
        }

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.transform.tag =="Player" || collision.transform.tag == "Cake" ) & !isCollide)
        {
            isCollide = true;

            gameObjectToLead = collision.transform;


        }
    }
}
