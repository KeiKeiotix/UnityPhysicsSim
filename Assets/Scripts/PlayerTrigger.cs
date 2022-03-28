using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{

    public Ragdoll ragdoll;



    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<R
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<CharacterMovement>() != null)
        {
            //Debug.Log("Hit a character");

            ragdoll.RagdollOn = ragdoll.RagdollOn == true ? false : true;
        }
    }
}
