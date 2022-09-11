using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public Transform Aim;
    public Camera Camera;
    public Transform PlayerBody;
    public float LerpRate;
    void Update()
    {
        Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 50f, Color.yellow);
        Plane plane = new Plane(-Vector3.forward, Vector3.zero);

        float distance;
        plane.Raycast(ray, out distance);
        Vector3 point = ray.GetPoint(distance);
        Aim.position = point;

        Vector3 toAim = Aim.position - transform.position;
        transform.rotation = Quaternion.LookRotation(toAim);

        if(toAim.x > 0f)
        {
            PlayerBody.rotation = Quaternion.Lerp(PlayerBody.rotation, Quaternion.Euler(0f, -45f, 0f), Time.deltaTime * LerpRate);
        }
        else
        {
            PlayerBody.rotation = Quaternion.Lerp(PlayerBody.rotation, Quaternion.Euler(0f, 45f, 0f), Time.deltaTime * LerpRate);
        }

        //RaycastHit hit;
        //if(Physics.Raycast(ray, out hit)){
        //    Debug.Log(hit.point);
        //    Aim.position = new Vector3(hit.point.x, hit.point.y, hit.point.z-0.1f);
        //    Aim.rotation = Quaternion.LookRotation(-hit.normal);
        //}
    }
}
