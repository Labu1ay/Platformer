using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTriggerEveryNSeconds
    : MonoBehaviour
{
    public float Period = 7f;
    public Animator Anim;
    private float _timer;
    public string NameAnim = "Attack";

    void Update()
    {
        _timer += Time.deltaTime;
        if(_timer > Period)
        {
            _timer = 0f;
            Anim.SetTrigger(NameAnim);
        }
    }
}
