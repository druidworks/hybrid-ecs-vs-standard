using UnityEngine;
using Unity.Entities;
using UnityStandardAssets.Vehicles.Ball;

public class Health : MonoBehaviour {

    [Range(0, 100)]
    public float currentHealth = 100;
    public float percentage = 1f;
    public bool hasUpdatedDamage = true;

    private MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (!hasUpdatedDamage)
        {
            UpdateMaterialColor(meshRenderer, percentage);
            foreach (MeshRenderer child in GetComponentsInChildren<MeshRenderer>())
            {
                UpdateMaterialColor(child, percentage);
            }
            hasUpdatedDamage = true;
        }
    }

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

    private void UpdateMaterialColor(MeshRenderer renderer, float colorPercentage)
    {
        if (renderer != null)
        {
            renderer.material.color = new Color(colorPercentage, 0f, 0f);
        }
    }
}
