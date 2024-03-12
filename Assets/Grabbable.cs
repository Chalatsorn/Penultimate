using UnityEngine;

public class Grabbable : MonoBehaviour
{
    private bool isGrabbed = false;
    private Transform grabber;
    private Vector3 originalPosition;
    private float repositionTimer = 0f;
    private float repositionThreshold = 5f; // Adjust this value as needed

    void Start()
    {
        // Store the original position of the object
        originalPosition = transform.position;
    }

    void Update()
    {
        // Check for input to grab the object
        if (Input.GetKeyDown(KeyCode.G) && !isGrabbed)
        {
            // Perform raycasting from the camera
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits this object
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    // Set this object as grabbed and store the grabber's transform
                    isGrabbed = true;
                    grabber = Camera.main.transform;
                }
            }
        }

        // If the object is grabbed, move it with the grabber
        if (isGrabbed)
        {
            // Calculate the new position of the object based on the grabber's position and forward direction
            Vector3 newPosition = grabber.position + grabber.forward * 2f;
            transform.position = newPosition;

            // Rotate the object to match the grabber's rotation
            transform.rotation = grabber.rotation;

            // Check for input to release the object
            if (Input.GetKeyDown(KeyCode.R))
            {
                isGrabbed = false;
            }
        }
        else
        {
            // If the object is not grabbed, start the reposition timer
            repositionTimer += Time.deltaTime;

            // If the object has been outside the designated zone for too long, reposition it
            if (repositionTimer >= repositionThreshold)
            {
                transform.position = originalPosition;
                repositionTimer = 0f; // Reset the timer
            }
        }
    }
}
