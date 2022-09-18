using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeGun : MonoBehaviour
{
    public Hook Hook;
    public Transform Spawn;
    public float Speed;

    private SpringJoint _springJoint;

   
    void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            Shot();
        }
    }

    void Shot()
    {
        if (_springJoint)
        {
            Destroy(_springJoint);
        }
        Hook.StopFix();
        Hook.transform.position = Spawn.position;
        Hook.transform.rotation = Spawn.rotation;
        Hook.Rigidbody.velocity = Spawn.forward * Speed;
    }

    public void SpringCreator()
    {
        if(_springJoint == null)
        {
            _springJoint = gameObject.AddComponent<SpringJoint>();
            _springJoint.connectedBody = Hook.Rigidbody;
            _springJoint.autoConfigureConnectedAnchor = false;
            _springJoint.connectedAnchor = Vector3.zero;
            _springJoint.spring = 100f;
            _springJoint.damper = 5f;
            _springJoint.maxDistance = 3f;
        }
    }
}
