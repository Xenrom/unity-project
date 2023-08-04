using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInstantiation : MonoBehaviour
{
    public GameObject prefabToInstantiate;
    public float launchForce = 10f;

    private GameObject instantiatedObject;

    private void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            if (instantiatedObject == null)
            {
                instantiatedObject = Instantiate(prefabToInstantiate, transform.position, Quaternion.identity);
            }
            else
            {
                Launch();
            }
        }
    }

    private void Launch()
    {
        Rigidbody rb = instantiatedObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Camera.main.transform.forward * launchForce;
        }
        instantiatedObject = null; // Reset the reference after launching
    }
}
