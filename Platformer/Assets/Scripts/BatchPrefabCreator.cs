using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatchPrefabCreator : MonoBehaviour
{
    public GameObject Prefab;
    public Transform [] PositionPoints;

    [ContextMenu("Create")]
    public void Create()
    {
        for (int i = 0; i < PositionPoints.Length; i++)
        {
            Instantiate(Prefab, PositionPoints[i].position, PositionPoints[i].rotation);
        }
    }
}
