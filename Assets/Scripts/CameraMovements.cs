using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovements : MonoBehaviour
{
    public float speed;
    private float vertical;
    public int raycastDistance;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Mouse Y");
        transform.Rotate(Vector3.right, -vertical * speed * Time.deltaTime);

        if (Input.GetKeyDown("e"))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance))
            {
                if (hit.collider.CompareTag("Interactable"))
                {
                    Debug.Log("interacted with: " + hit.collider.gameObject.name);
                }
            }
        }
    }
}
