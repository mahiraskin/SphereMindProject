using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class DropToGame: MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    public GameObject Ex;

    void OnMouseDown()
    {
        GameObject go = Instantiate(Ex, Vector3.zero, Quaternion.identity);
        go.GetComponent<NetworkObject>().Spawn();

        mZCoord = Camera.main.WorldToScreenPoint(go.transform.position).z;

        // Store offset = gameobject world pos - mouse world pos
        mOffset = go.transform.position - GetMouseAsWorldPoint();
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object on screen
        mousePoint.z = mZCoord;

        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseAsWorldPoint() + mOffset;
    }
}