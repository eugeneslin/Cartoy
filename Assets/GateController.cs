using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    public GameObject FirstDetector;
    public GameObject SecondDetector;
    public GameObject Arrow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        print("Tag: " + other.gameObject.tag);
        if (other.gameObject.CompareTag("Player"))
        {
            CompleteGate();
        }
    }

    void CompleteGate()
    {
        ParticleSystem[] particleSystems = GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem ps in particleSystems)
        {
            ps.Play();
        }

        FirstDetector.SetActive(false);
        SecondDetector.SetActive(false);
        Arrow.SetActive(false);
    }
}
