using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class TapSystem : MonoBehaviour
{
    [SerializeField] private float sensitivityRb;

    [SerializeField] private Transform[] gameObjectsPosition; //массив элементов дл€ системы частиц и пушки | 0 - drivers, 1 - shooting

    [SerializeField] private GameObject[] bullets;
    private AmmoManager ammo;
    public Text ammoStatictics;

    [SerializeField] private GameObject[] toInstantiateObjects; //объекты которые будут создаватьс€ | 0 - drivers, 1 - shooting

    [SerializeField] private Vector3 tapStart;
    [SerializeField] private Vector3 tapEnd;
    [SerializeField] private float speed;

    Rigidbody rb;

    public Text tapsStatistics;
    [SerializeField] int taps;

    private Animation anim;

    //заглушки дл€ перехода на раздые стороны
    public byte side; //0- на месте, 1- права€, 2- лева€
    public float coorXTo;
    void Start()
    {
        anim = GetComponent<Animation>();
        side = 0;
        rb = GetComponent<Rigidbody>();
        ammo = GetComponent<AmmoManager>();
    }

    void Update()
    {
        ammoStatictics.text = Convert.ToString(ammo.bullets);
        tapsStatistics.text = Convert.ToString(taps);


        if (coorXTo > 5f)
        {
            coorXTo = 5f;
        }
        else if(coorXTo < -5f)
        {
            coorXTo = -5f;
        }
      
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -5f, 5f), transform.position.y, transform.position.z);
        switch (side)
        {
            case 0:
                transform.position = transform.position;
                break;
            case 1:
                if (transform.position.x != coorXTo)
                {
                    transform.position = Vector3.Lerp(transform.position, new Vector3(coorXTo, transform.position.y, transform.position.z), Time.deltaTime * speed);
                }
                else
                {
                    side = 0;
                }
                break;
            case 2:
                if (transform.position.x != coorXTo)
                {
                    transform.position = Vector3.Lerp(transform.position, new Vector3(coorXTo, transform.position.y, transform.position.z), Time.deltaTime * speed);
                }
                else
                {
                    side = 0;
                }
                break;
        }
        switch (GameHandler.gameHandlerSington.gameStart)
        {
            case true:
                rb.isKinematic = false;
                HandleTouch();
                break;
            case false:
                rb.isKinematic = true;
                break;
        } 
    }

    private void Push(in float sensitivity)
    {
        rb.AddForce(Vector3.up * sensitivity, ForceMode.Impulse);
        Instantiate(toInstantiateObjects[0], gameObjectsPosition[0]);
    }

    private void Shoot()
    {
        Instantiate(toInstantiateObjects[1], gameObjectsPosition[1]);
        ammo.BulletDown();
        if(ammo.bullets < 0)
        {
            ammo.bullets = 0;
        }
    }

    private void HandleTouch()
    {

        if (Input.touchCount > 0 && Input.touchCount != 2)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                tapStart = touch.position;
            }
            if (touch.phase == TouchPhase.Moved)
            {
                tapEnd = touch.position;
            }
            if(touch.phase == TouchPhase.Ended)
            {
                TapPlus();
                HandleTouchPosition();
                tapStart = Vector3.zero;
                tapEnd = Vector3.zero;
            }
        }
        else if (Input.touchCount == 2)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                TapPlus();
                if (ammo.bullets > 0)
                Shoot();
            }
        }
    }
    private void HandleTouchPosition()
    {
        if(tapStart.x - tapEnd.x >= 50f && tapEnd.x != 0)
        {
            if (transform.position.x >= -4.9f)
            {
                anim.Play("ToLeft");
            }
            coorXTo = transform.position.x - 5f;
            side = 2;
        }
        else if(tapStart.x - tapEnd.x <= -50f && tapEnd.x != 0)
        {
            if (transform.position.x <= 4.9f)
            {
                anim.Play("ToRight");
            }
            coorXTo = transform.position.x + 5f;
            side = 1;
        }
        else
        {
            rb.velocity = Vector3.zero;
            Push(in sensitivityRb);
        }
    }
    void TapPlus()
    {
        taps++;
    }
}