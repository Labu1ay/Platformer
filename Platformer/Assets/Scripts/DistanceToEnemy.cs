using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class DistanceToEnemy : MonoBehaviour
{
    public float RadiusDistanceToPlayer = 20f;

    public List<GameObject> EnemiesList = new List<GameObject>();
    private GameObject[] _enemies;
    //private EnemyHealth[] _enemies;

    private void Start()
    {
        _enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //_enemies = FindObjectsOfType<EnemyHealth>();

        for (int i = 0; i < _enemies.Length; i++)
        {
            EnemiesList.Add(_enemies[i]);
            EnemiesList[i].SetActive(false);
        }
    }
    void Update()
    {
        for (int i = 0; i < EnemiesList.Count; i++)
        {
            float distanceToPlayer = Vector3.Distance(EnemiesList[i].transform.position, transform.position);

            if (distanceToPlayer < RadiusDistanceToPlayer)
            {
                EnemiesList[i].SetActive(true);
                EnemiesList.Remove(EnemiesList[i]);
            }
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.gray;
        Handles.DrawWireDisc(transform.position, Vector3.forward, RadiusDistanceToPlayer);
    }
#endif
}
