using UnityEngine;

public class GrabbableObjectInteraction : MonoBehaviour
{
    // Add any necessary variables here

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision involves a collider with a specific tag or layer
        if (collision.gameObject.CompareTag("Interactable"))
        {
            // Perform actions based on the collision
            Debug.Log("Grabbable object collided with an interactable object.");

            // Example: Turn on a light GameObject
            Light lightComponent = collision.gameObject.GetComponent<Light>();
            if (lightComponent != null)
            {
                lightComponent.enabled = true;
            }

            // Example: Play a sound effect
            AudioSource audioSource = GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the trigger zone was entered by a specific object
        if (other.CompareTag("TriggerZone"))
        {
            // Perform actions based on entering the trigger zone
            Debug.Log("Grabbable object entered a trigger zone.");

            // Example: Activate a particle system
            ParticleSystem particleSystem = other.GetComponent<ParticleSystem>();
            if (particleSystem != null)
            {
                particleSystem.Play();
            }

            // Example: Change the material color of the grabbable object
            Renderer renderer = GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = Color.green;
            }
        }
    }
}
