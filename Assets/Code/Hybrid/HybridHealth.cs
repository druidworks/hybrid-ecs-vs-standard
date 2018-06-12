using UnityEngine;
using Unity.Entities;
using UnityStandardAssets.Vehicles.Ball;

public class HybridHealth : MonoBehaviour {
    [Range(0,100)]
    public float currentHealth = 100;
    public float percentage = 1f;
    public bool hasUpdatedDamage = true;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Ball>() != null || collision.gameObject.GetComponent<HybridRotator>() != null || collision.gameObject.GetComponent<Rotator>() != null)
        {
            Reduce(5);
        }
    }

    public void Reduce(int by)
    {
        currentHealth -= by;
        percentage = (float)(currentHealth / 100f);

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            GameManager.DecrementBallCountText();
        }
        else
        {
            hasUpdatedDamage = false;
        }
    }
}

class HealthSystem : ComponentSystem
{
    struct Component
    {
        public HybridHealth health;
    }

    protected override void OnUpdate()
    {
        var time = Time.deltaTime;
        GameObject playerInstance = GameManager.GetPlayerInstance();

        ComponentGroupArray<Component> components = GetEntities<Component>();

        foreach (var e in components)
        {
            if (!e.health.hasUpdatedDamage)
            {
                MeshRenderer renderer = e.health.GetComponent<MeshRenderer>();
                UpdateMaterialColor(renderer, e.health.percentage);
                foreach (MeshRenderer child in e.health.GetComponentsInChildren<MeshRenderer>())
                {
                    UpdateMaterialColor(child, e.health.percentage);
                }
                
                e.health.hasUpdatedDamage = true;
            }            
        }
    }

    private void UpdateMaterialColor(MeshRenderer renderer, float percentage)
    {
        if (renderer != null)
        {
            renderer.material.color = new Color(percentage, 0f, 0f);
        }
    }
}
