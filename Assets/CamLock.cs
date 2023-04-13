using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamLock : MonoBehaviour
{
    // Start is called before the first frame update
    private Cinemachine.CinemachineFreeLook freelook;
    private int lockCam;
    void Start()
    {
        lockCam = 0;
        freelook = GetComponentInParent<Cinemachine.CinemachineFreeLook>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            lockCam++;

            if (lockCam % 2 == 1)
                freelook.enabled = false;
            else
                freelook.enabled = true;
        }
    }
}
