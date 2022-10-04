using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public float speedB;
    [SerializeField] private float timeToDestroy;

    AmmoManager ammoManager;
    private void Start()
    {
        ammoManager = GameObject.FindWithTag("Player").GetComponent<AmmoManager>();
        Invoke("DestroyBullet", timeToDestroy);
    }
    void Update()
    {
        Go();
    }
    private void Go()
    {
        transform.Translate(Vector3.up * speedB * Time.deltaTime);
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "meteor")
        {
            Destroy(other.gameObject);
            ammoManager.BulletUp();
            DestroyBullet();
        }
    }
}
