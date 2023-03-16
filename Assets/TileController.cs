using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    public GameObject TileFragment;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void DoDriftDamage()
    {
        Explode();
        Destroy(gameObject, (float)3.0f);
    }

    public float speed = 1.0f;
    public float fadeTime = 3.0f;

    void Explode()
    {
        float spacing = 0.5f;
        Vector3 center = transform.position;
        Vector3 offset = new Vector3(-spacing, 0, -spacing) * 1.5f;
        for (int i = 0; i < 16; i++)
        {
            Vector3 pos = center + offset;
            GameObject obj = Instantiate(TileFragment, pos + Vector3.up * 0.1f, Quaternion.identity);
            obj.transform.localScale = Vector3.one * 0.25f;
            obj.GetComponent<Renderer>().material = GetComponent<Renderer>().material;
            obj.GetComponent<MeshCollider>().enabled = false;
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            rb.angularVelocity = Random.insideUnitSphere * 100;
            rb.AddExplosionForce(Random.Range(100, 400), transform.position, Random.Range(500, 1000), 0);
            Destroy(obj, Random.Range(3.0f, 5.0f));
            offset.x += spacing;
            if (offset.x > spacing * 1.5f)
            {
                offset.x = -spacing * 1.5f;
                offset.z += spacing;
            }
        }
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
