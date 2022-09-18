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

    public ParticleSystem SmokeEffect;
    private void Update()
    {
        _timer += Time.unscaledDeltaTime;

        if (_timer > ShotPeriod)
        {
            if (Input.GetMouseButton(0))
            {
                _timer = 0f;
                Shot();
            }
        }
    }
    public virtual void Shot()
    {
        GameObject newBulletPrefab = Instantiate(BulletPrefab, SpawnBullet.position, SpawnBullet.rotation);
        newBulletPrefab.GetComponent<Rigidbody>().velocity = SpawnBullet.forward * SpeedBullet;
        ShotSound.pitch = Random.Range(0.8f, 1.21f);
        ShotSound.Play();
        Flash.SetActive(true);
        Invoke("HideFlash", 0.08f);
        SmokeEffect.Play();
    }

    void HideFlash()
    {
        Flash.SetActive(false);
    }

    public virtual void Activate()
    {
        gameObject.SetActive(true);
    }
    public virtual void Deactivate()
    {
        gameObject.SetActive(false);
    }
    public virtual void AddBullets(int numberOfBullets)
    {

    }
}
