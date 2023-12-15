using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeController : MonoBehaviour
{
     bool isCollide, isFluidCollide;
     Transform gameObjectToLead;

     [SerializeField] Transform Dough;
     // Start is called before the first frame update
     void Start()
     {
          isCollide = false;
          isFluidCollide = false;
          Dough.gameObject.SetActive(false);

     }

     // Update is called once per frame
     void Update()
     {
          if (isCollide)
          {
               transform.position += new Vector3(0, 0, -gameObjectToLead.GetComponent<PlayerController>().ballSpeed * Time.deltaTime);
               transform.position = new Vector3(gameObjectToLead.GetComponent<PlayerController>().newX, transform.position.y, transform.position.z);
          }


     }

     private void OnTriggerEnter(Collider collision)
     {
           if ((collision.transform.tag == "Player" || collision.transform.tag == "Cake") & !isCollide)
          {
               isCollide = true;

               gameObjectToLead = collision.transform;


          }

          if ((collision.transform.tag == "Fluid" ) & !isFluidCollide)
          {
               isFluidCollide = true;

               Dough.gameObject.SetActive(true);
          }
     }
}
