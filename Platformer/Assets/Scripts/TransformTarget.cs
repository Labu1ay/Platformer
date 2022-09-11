using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformTarget : MonoBehaviour
{
    public Transform Target;

    private void Update()
    {
        transform.position = Target.position;
    }
}
