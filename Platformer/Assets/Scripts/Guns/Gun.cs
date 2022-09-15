using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform SpawnBullet;
    public float SpeedBullet;
    public float ShotPeriod;

    private float _timer;

    public AudioSource ShotSound;
    public GameObject Flash;
    private void Update()
    {
        _timer += Time.deltaTime;


        if (_timer > ShotPeriod)
        {
            if (Input.GetMouseButton(0))
            {
                _timer = 0f;
                Shot();
            }
        }
    }
    void Shot()
    {
        GameObject newBulletPrefab = Instantiate(BulletPrefab, SpawnBullet.position, SpawnBullet.rotation);
        newBulletPrefab.GetComponent<Rigidbody>().velocity = SpawnBullet.forward * SpeedBullet;
        ShotSound.pitch = Random.Range(0.8f, 1.21f);
        ShotSound.Play();
        Flash.SetActive(true);
        Invoke("HideFlash", 0.08f);
    }

    void HideFlash()
    {
        Flash.SetActive(false);
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }
    public void Diactivate()
    {
        gameObject.SetActive(false);
    }
}
