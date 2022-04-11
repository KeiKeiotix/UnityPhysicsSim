using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kinematic : MonoBehaviour
{
    public Vector3 startPos = new Vector3(15, 0.25f, 9);
    public Vector3 endPos = new Vector3(15, 2.75f, 9);

    public float moveSpeed = 0.25f;

    Transform liftTransform;
    Rigidbody rb;

    Vector3 targetPos;

    GameObject temp;

    // Start is called before the first frame update
    void Start()
    {
        liftTransform = transform.parent;
        rb = liftTransform.GetComponent<Rigidbody>();

        targetPos = startPos;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (liftTransform.position != targetPos)
        {

            rb.position = Vector3.MoveTowards(liftTransform.position, targetPos, moveSpeed * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.GetComponent<CharacterMovement>() != null)
        {
            other.transform.SetParent(liftTransform, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<CharacterMovement>() != null)
        {
            other.transform.SetParent(null, true);
        }
    }

    public void GoToStart()
    {
        targetPos = startPos;
    }

    public void GoToEnd()
    {
        targetPos = endPos;

    }
}
