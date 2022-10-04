using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public float speedB;
    [SerializeField] private float timeToDestroy;

    AmmoManager ammoManager;

    [SerializeField] private GameObject OBJ_BAX;
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
            Instantiate(OBJ_BAX, new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z), Quaternion.identity);
            Destroy(other.gameObject);
            ammoManager.BulletUp();
            DestroyBullet();
        }
    }
}
