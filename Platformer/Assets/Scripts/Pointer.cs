using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public Transform Aim;
    public Camera Camera;
    public Transform PlayerBody;
    public float LerpRate;

    private float _yEuler;
    void LateUpdate()
    {
                                                            //with the help of the ray the sight is aim
        Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 50f, Color.yellow);
        Plane plane = new Plane(-Vector3.forward, Vector3.zero);

        float distance;
        plane.Raycast(ray, out distance);
        Vector3 point = ray.GetPoint(distance);
        Aim.position = point;

                                                        //needed to rotate gun in plane Z
        Vector3 toAim = Aim.position - transform.position;
        transform.rotation = Quaternion.LookRotation(toAim);

        //with the help of this check, we turn the player towards the aim
        if (toAim.x < 0f)
        {
            _yEuler = Mathf.Lerp(_yEuler, 45f, Time.deltaTime * LerpRate);
        }
        else
        {
            _yEuler = Mathf.Lerp(_yEuler, -45f, Time.deltaTime * LerpRate);
        }
        PlayerBody.localEulerAngles = new Vector3(0, _yEuler, 0);

        //RaycastHit hit;
        //if(Physics.Raycast(ray, out hit)){
        //    Debug.Log(hit.point);
        //    Aim.position = new Vector3(hit.point.x, hit.point.y, hit.point.z-0.1f);
        //    Aim.rotation = Quaternion.LookRotation(-hit.normal);
        //}
    }
}
