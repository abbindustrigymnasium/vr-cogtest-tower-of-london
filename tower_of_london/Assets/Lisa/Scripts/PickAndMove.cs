using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAndMove : MonoBehaviour
{
    private float raycastMaxDistance = 100000.0f;

    private static bool moving = false;
    private Vector3 old_position;
    private Transform old_parent;
    private Transform target;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!moving)
            {
                Pick();
            } else
            {
                Release();
            }
        }

        if (moving && target != null)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                target.position = new Vector3(target.position.x-2, target.position.y, target.position.z);
            } else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                target.position = new Vector3(target.position.x+2, target.position.y, target.position.z);
            } else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                target.position = new Vector3(target.position.x, target.position.y+2, target.position.z);
            } else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                target.position = new Vector3(target.position.x, target.position.y-2, target.position.z);
            }
        }
    }

    void Pick()
    {
        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        LayerMask mask = LayerMask.GetMask("Plate");

        if (Physics.Raycast(ray, out hit, raycastMaxDistance, mask))
        {
            if(hit.transform.gameObject.tag == "Plate")
            {
                Plate plate = hit.transform.gameObject.GetComponent<Plate>();
                if (plate.isOnTop)
                {
                    // Lock to mouse position
                    target = hit.transform;

                    old_position = target.position;
                    old_parent = target.parent;

                    moving = true;

                    target.GetComponent<Rigidbody>().useGravity = false;
                    target.position = new Vector3(target.position.x, 4, target.position.z);
                }
            }
        }
    }

    void Release()
    {
        // Check if allowed placement
        if (!ValidPlacement())
        {
            //Return to former position
            target.parent = old_parent;
            target.position = old_position;
        } else
        {
            // If allowed snap to drop position
            target.position = target.parent.position + new Vector3(0, 4, 0);
        }
        target.GetComponent<Rigidbody>().useGravity = true;
        target = null;
        moving = false;
    }

    bool ValidPlacement()
    {
        Tower target_tower = target.parent.GetComponent<Tower>();
        
        int count = target_tower.PlatesOnTower.Count;
        if (count <= 1) return true;

        Plate.Size target_size = target_tower.PlatesOnTower[count - 2].size;
        Plate.Size size = target.GetComponent<Plate>().size;

        // Check if max amount of disks on tower
        if (count <= 0 || count >= 9) return false;
        // Check if size is smaller or equal
        switch(size)
        {
            case Plate.Size.Small:
                break;
            case Plate.Size.Medium:
                if (target_size == Plate.Size.Small) return false;
                break;
            case Plate.Size.Large:
                if (target_size == Plate.Size.Small || target_size == Plate.Size.Medium) return false;
                break;
        }
        // Check if colour mode is enabled
            // Check if not same colour
            // Debug.Log(target_tower.PlatesOnTower[count-1].colour);
        return true;
    }

    bool CheckSize()
    {
        return false;
    }
}
