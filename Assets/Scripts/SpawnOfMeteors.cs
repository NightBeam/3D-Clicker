using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOfMeteors : MonoBehaviour
{
    public GameObject Player;
    [SerializeField] private GameObject meteor;

    [SerializeField] private bool createNewMeteors;
    [SerializeField] private float YNewMeteors;


    [SerializeField] private float delay =0;
    [SerializeField] private float spawnCoord;
    private void Start()
    {
        createNewMeteors = true;
        YNewMeteors = Player.transform.position.y + 32f;
    }
    private void Update()
    {
        switch (GameHandler.gameHandlerSington.gameStart)
        {
            case true:
                SpawnMeteorM();
                break;
            case false:

                break;
        }
    }
    private void SpawnMeteorM()
    {
        if(Player != null)
        {

            if (createNewMeteors == true)
            {
                if(Player.transform.position.y < YNewMeteors)
                {
                    spawnCoord = YNewMeteors;
                    foreach (int i in new int[Random.Range(5, 10)])
                    {
                        Invoke("Spawn", delay);
                        delay += 0.5f;
                    }
                    delay = 0f;
                    createNewMeteors = false;
                }
            }
            else
            {
                if (Player.transform.position.y >= YNewMeteors)
                {
                    YNewMeteors = Player.transform.position.y + 32f;
                    createNewMeteors = true;
                }
            }
        }
    }
    void Spawn()
    {
        Instantiate(meteor, new Vector3(Random.Range(-6, 7), spawnCoord+=(Random.Range(5f, 10f)), 5.7f), Quaternion.identity);
    }
}
