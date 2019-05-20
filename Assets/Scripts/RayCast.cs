using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    public delegate void RayCastAction(Premetive newModel);
    public static event RayCastAction OnHitRayCast;

    public Camera mainCam;
    public Camera portalCamera;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

            // do we hit our portal plane?
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.textureCoord);
                var localPoint = hit.textureCoord;
                // convert the hit texture coordinates into camera coordinates
                Ray portalRay = portalCamera.ScreenPointToRay(new Vector2(localPoint.x * portalCamera.pixelWidth, localPoint.y * portalCamera.pixelHeight));
                RaycastHit hit2;
                // test these camera coordinates in another raycast test
                if (Physics.Raycast(portalRay, out hit2))
                {
                    Debug.Log(hit2.collider.gameObject);
                    hit2.collider.GetComponent<Premetive>().GetInfo();
                    OnHitRayCast?.Invoke(hit2.collider.GetComponent<Premetive>());
                }
            }
        }

    }
}

