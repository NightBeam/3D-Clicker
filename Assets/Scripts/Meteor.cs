using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Meteor : MonoBehaviour
{
    [SerializeField] private float speed;
    GameObject player;
    [SerializeField] private float distanceBetweenRAndM;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        float randomScale = Random.Range(100f, 351f);
        transform.localScale = new Vector3(randomScale, randomScale, randomScale);
    }

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime,Space.World);
        if(player != null)
        {
            if (transform.position.y <= player.transform.position.y - distanceBetweenRAndM)
            {
                DestroyM();
            }
        }
    }

    void DestroyM()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
            EndGame eg = GameObject.Find("Handler").GetComponent<EndGame>();
            eg.endGame = true;
        }
     
    }
}
