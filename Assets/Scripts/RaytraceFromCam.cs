using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaytraceFromCam : MonoBehaviour
{

    public Camera cam;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    public void TryClickRagdoll()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {

            Transform currentObject = hit.transform;

            while (currentObject != null)
            {
                if (currentObject.GetComponent<Ragdoll>() != null)
                {
                    currentObject.GetComponent<Ragdoll>().RagdollOn = true;
                    break;
                }
                currentObject = currentObject.parent;              
            }
        }
    }

}
