using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayWhenDrifting : MonoBehaviour
{
    public GameObject Shrapnel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PrometeoCarController prometeoCarController = GetComponentInParent<PrometeoCarController>();
        bool isDrifting = prometeoCarController.isDrifting;
        if(isDrifting)
        {
            EmitSpray();
        }
    }

    void EmitSpray()
    {
        if(Random.Range(0, 10) != 0)
        {
            return;
        }
        PrometeoCarController prometeoCarController = GetComponentInParent<PrometeoCarController>();
        Vector3 fragmentSize = new Vector3(0.015f, 0.035f, 0.035f);
        for (int i = 0; i < 1; i++)
        {
            GameObject obj = Instantiate(Shrapnel, transform.position, transform.rotation);
            obj.transform.localScale = fragmentSize;
            //obj.GetComponent<Renderer>().material = GetComponent<Renderer>().material;
            //obj.GetComponent<MeshCollider>().enabled = false;
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            rb.velocity = prometeoCarController.GetComponent<Rigidbody>().velocity + prometeoCarController.transform.forward * -Random.Range(10f, 15f);
            rb.velocity += prometeoCarController.transform.right * Random.Range(-5f, 5f) + prometeoCarController.transform.right * prometeoCarController.localVelocityX;
            rb.angularVelocity = Random.insideUnitSphere * 100;
            Destroy(obj, Random.Range(3.0f, 5.0f));

            GameObject player = prometeoCarController.gameObject;
            Collider[] colliders = player.GetComponentsInChildren<Collider>();
            foreach (Collider collider in colliders)
            {
                if (collider != null)
                {
                    Physics.IgnoreCollision(collider, obj.GetComponent<Collider>());
                }
            }
        }
    }
}
