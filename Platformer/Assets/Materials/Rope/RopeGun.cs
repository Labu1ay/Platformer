using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RopeState
{
    Disabled,
    Fly,
    Active
}

public class RopeGun : MonoBehaviour
{
    public Hook Hook;
    public Transform Spawn;
    public float Speed;

    private SpringJoint _springJoint;
    public Transform RopeStart;
    private float _length;

    public RopeState CurrentRopeState;
    public RopeRenderer RopeRenderer;
    public PlayerMove PlayerMove;
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Shot();
        }
        if(CurrentRopeState == RopeState.Fly)
        {
            float distance = Vector3.Distance(RopeStart.position, Hook.transform.position);
            if (distance > 20f)
            {
                Hook.gameObject.SetActive(false);
                CurrentRopeState = RopeState.Disabled;
                RopeRenderer.Hide();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(CurrentRopeState == RopeState.Active)
            {
                if(PlayerMove.Grounded == false)
                {
                    PlayerMove.Jump();
                }
            }
            DestroySpring();
        }
        if(CurrentRopeState == RopeState.Fly || CurrentRopeState == RopeState.Active)
        {
            RopeRenderer.Draw(RopeStart.position, Hook.transform.position, _length);
        }
    }

    void Shot()
    {
        _length = 1f;
        if (_springJoint)
        {
            Destroy(_springJoint);
        }
        Hook.gameObject.SetActive(true);
        Hook.StopFix();
        Hook.transform.position = Spawn.position;
        Hook.transform.rotation = Spawn.rotation;
        Hook.Rigidbody.velocity = Spawn.forward * Speed;

        CurrentRopeState = RopeState.Fly;
    }

    public void SpringCreator()
    {
        if(_springJoint == null)
        {
            _springJoint = gameObject.AddComponent<SpringJoint>();
            _springJoint.connectedBody = Hook.Rigidbody;
            _springJoint.connectedAnchor = RopeStart.localPosition;
            _springJoint.autoConfigureConnectedAnchor = false;
            _springJoint.connectedAnchor = Vector3.zero;
            _springJoint.spring = 100f;
            _springJoint.damper = 5f;

            _length = Vector3.Distance(RopeStart.position, Hook.transform.position);
            _springJoint.maxDistance = _length;

            CurrentRopeState = RopeState.Active;
        }
    }
    public void DestroySpring()
    {
        if (_springJoint)
        {
            Destroy(_springJoint);
            CurrentRopeState = RopeState.Disabled;
            Hook.gameObject.SetActive(false);
            RopeRenderer.Hide();
        }
    }
}
