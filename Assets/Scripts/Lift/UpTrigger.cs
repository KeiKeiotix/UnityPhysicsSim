using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpTrigger : MonoBehaviour
{

    public Kinematic mainTriggerBox;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CharacterMovement>() != null)
        {
            mainTriggerBox.GoToEnd();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<CharacterMovement>() != null)
        {
            mainTriggerBox.GoToStart();
        }
    }

}
