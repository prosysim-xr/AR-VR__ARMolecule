using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public GameObject go_h1_collider;
    public GameObject go_h2_collider;


    void OnCollisionStay(Collision collision)
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        

        if(Utility.has_h1_o_Collided == true)
        {
            if (!(other.gameObject.name == go_h1_collider.name))
            {
                Utility.is_h1_o_not_colliding_anymore = true;
            }
        }
        if(Utility.has_h2_o_Collided == true)
        {
            if (!(other.gameObject.name == go_h2_collider.name))
            {
                Utility.is_h2_o_not_colliding_anymore = true;
            }
        }


        if (other.gameObject.name == go_h1_collider.name)
        {
            Debug.Log("Collided with====" + go_h1_collider.name);
            Utility.has_h1_o_Collided = true;
        }
        if(other.gameObject.name == go_h2_collider.name)
        {
            Debug.Log("Collided with====" + go_h2_collider.name);
            Utility.has_h2_o_Collided = true;
        }


    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == go_h1_collider.name)
        {
            Debug.Log("exiting collision from====" + go_h1_collider);
            Utility.has_h1_o_Collided = false;
        }
        else if(other.gameObject.name == go_h2_collider.name)
        {
            Debug.Log("exiting collision from====" + go_h2_collider);
            Utility.has_h2_o_Collided = false;
        }
    }
}
