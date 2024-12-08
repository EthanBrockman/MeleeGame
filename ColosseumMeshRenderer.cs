using MeshRendering;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeshRendering
{
    // Custom Mesh Renderer handler class
    public class ColosseumMeshRenderer
    {
        // Method to add a Mesh Renderer to a GameObject
        public void AddMeshRenderer(GameObject targetObject, Material material)
        {
            // Ensure the target object exists
            if (targetObject == null)
            {
                Debug.LogError("Target object is null. Cannot add a Mesh Renderer.");
                return;
            }

            // Check if the object already has a Mesh Renderer
            UnityEngine.MeshRenderer meshRenderer = targetObject.GetComponent<UnityEngine.MeshRenderer>();
            if (meshRenderer == null)
            {
                // Add Mesh Renderer component
                meshRenderer = targetObject.AddComponent<UnityEngine.MeshRenderer>();
                Debug.Log("Mesh Renderer added to " + targetObject.name);
            }
            else
            {
                Debug.Log("Mesh Renderer already exists on " + targetObject.name);
            }

            // Assign material if provided
            if (material != null)
            {
                meshRenderer.material = material;
            }
            else
            {
                Debug.LogWarning("No material provided for the Mesh Renderer.");
            }
        }
    }
}

public class Program : MonoBehaviour
{
    // Reference to the prefab
    public GameObject colosseumPrefab;

    // Material to apply to the Mesh Renderer
    public Material defaultMaterial;

    // Start method called when the script instance is loaded
    void Start()
    {
        if (colosseumPrefab == null)
        {
            Debug.LogError("Colosseum prefab not assigned.");
            return;
        }

        // Find "Element 0" child
        Transform element0Transform = colosseumPrefab.transform.Find("Element 0");
        if (element0Transform == null)
        {
            Debug.LogError("Child 'Element 0' not found in Colosseum prefab.");
            return;
        }

        GameObject element0 = element0Transform.gameObject;

        // Create an instance of the ColosseumMeshRenderer class
        ColosseumMeshRenderer colosseumMeshRenderer = new ColosseumMeshRenderer();

        // Call the AddMeshRenderer method on the colosseumMeshRenderer instance (NOT MeshRenderer)
        colosseumMeshRenderer.AddMeshRenderer(element0, defaultMaterial);
    }
}


