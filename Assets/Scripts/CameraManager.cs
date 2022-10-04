using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private float cameraSensitivity;
    [SerializeField] private GameObject Player;

    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        if(Player != null)
        {
            transform.position = new Vector3(transform.position.x, Player.transform.position.y + 8f, transform.position.z);
        }
    }
}
