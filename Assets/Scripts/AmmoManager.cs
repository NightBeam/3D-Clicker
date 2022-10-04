using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    public int bullets;

    private void Start()
    {
        bullets = 3;
    }
    public void BulletUp()
    {
        bullets++;
    }
    public void BulletDown()
    {
        bullets--;
    }
}
