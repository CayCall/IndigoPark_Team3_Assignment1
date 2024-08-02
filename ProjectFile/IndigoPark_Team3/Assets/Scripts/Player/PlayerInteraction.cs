using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private Camera uiCamera;
    [SerializeField] private float distance = 3f;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private gearsInventory inventory;

    [SerializeField] private GameObject CritterCuff;

    private void Start()
    {
        uiCamera = Camera.main;
    }

    private void Update()
    {
        Ray ray = new Ray(uiCamera.transform.position, uiCamera.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, distance, layerMask))
        {

            Gears gear = hitInfo.collider.GetComponent<Gears>();
            Generator generator = hitInfo.collider.GetComponent<Generator>();

            // Check if the hit object has the "Box" tag
            if (hitInfo.collider.CompareTag("PuzzleBox"))
            {
                PuzzleBoxSpin boxSpin = hitInfo.collider.GetComponent<PuzzleBoxSpin>();

                if (boxSpin != null && Input.GetKeyDown(KeyCode.F) && !boxSpin.IsRotating())
                {
                    Debug.Log("Box detected: " + hitInfo.collider.name);
                    boxSpin.StartRotation();
                }
            }

            if (gear != null && Input.GetKeyDown(KeyCode.F))
            {
                PickupGear(gear);
            }
            else if (generator != null && Input.GetKeyDown(KeyCode.F))
            {
                generator.GeneratorStart();
            }
        }
    }

    private void PickupGear(Gears gear)
    {
        List<Gears> gearList = new List<Gears>(inventory.gearsController);
        gearList.Add(gear);
        inventory.gearsController = gearList.ToArray();
        Destroy(gear.gameObject);
    }
}
