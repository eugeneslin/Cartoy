using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    public GateController nextGate = null;
    public bool isLeft = true;

    public GameObject FirstDetector;
    public GameObject SecondDetector;
    public GameObject Arrow;
    public GameObject FlagActive;
    public GameObject FlagInactive;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Gate Start").GetComponent<GateController>().ActivateGate();
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

    void ActivateGate()
    {
        FirstDetector.SetActive(true);
        SecondDetector.SetActive(true);
        Arrow.SetActive(true);
        FlagActive.SetActive(true);
        FlagInactive.SetActive(false);
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
        FlagActive.SetActive(false);
        FlagInactive.SetActive(true);

        if (nextGate != null)
        {
            nextGate.ActivateGate();
        }
    }
}
