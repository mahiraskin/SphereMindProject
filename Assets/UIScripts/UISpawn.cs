using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class UISpawn : MonoBehaviour
{
    public Button But;
    public GameObject Ex;
    //Character Specific Prefab To Be Inisantiated
    public Transform PTransform;
    void Start()
    {
        But.onClick.AddListener(Spawn);
    }

    // Update is called once per frame
    void Spawn()
    {
        GameObject go = Instantiate(Ex, Vector3.zero, Quaternion.identity, PTransform);
        go.GetComponent<NetworkObject>().Spawn();

    }
}
