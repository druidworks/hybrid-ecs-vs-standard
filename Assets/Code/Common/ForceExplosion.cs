using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceExplosion : MonoBehaviour {
    public float radius = 5.0F;
    public float power = 10.0F;

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
            foreach (Collider hit in colliders)
            {
                if (hit.gameObject.GetComponent<HybridChaser>() || hit.gameObject.GetComponent<Chaser>())
                {
                    Rigidbody rb = hit.GetComponent<Rigidbody>();

                    if (rb != null)
                    {
                        Health cc = rb.GetComponent<Health>();
                        if (cc != null)
                        {
                            cc.Reduce(5);
                        }

                        HybridHealth health = rb.GetComponent<HybridHealth>();
                        if (health != null)
                        {
                            health.Reduce(5);
                        }
                        rb.AddExplosionForce(power, explosionPos, radius, 3.0F);                        
                    }
                }
            }
        }
    }
}
