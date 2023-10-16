using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private bool isDragging = false;
    public List<GameObject> selectedObjects = new List<GameObject>();

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetMouseDragStart();
        }
        if (isDragging)
        {
            GetMouseDragUpdate();
        }
        if (Input.GetMouseButtonUp(0))
        {
            GetMouseDragEnd();
        }
    }

    public void GetMouseDragStart()
    {
        isDragging = true;
    }

    public void GetMouseDragUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            GameObject selectedObject = hit.collider.gameObject;
            if (selectedObject.CompareTag("Coin"))
            {
                selectedObject.GetComponent<Renderer>().material.color = Color.red;
                if (!selectedObjects.Contains(selectedObject))
                {
                    selectedObjects.Add(selectedObject);
                }
            }
        }
    }

    public void GetMouseDragEnd()
    {
        isDragging = false;
        List<GameObject> destroyObjects = new List<GameObject>(selectedObjects);
        selectedObjects.Clear();
        foreach (var obj in destroyObjects)
        {
            Coin coin = obj.GetComponent<Coin>();
            if (coin != null)
            {
                coin.DestroyCoin();
            }
        }
        destroyObjects.Clear();
    }
}
