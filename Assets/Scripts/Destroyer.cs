﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bg" || collision.gameObject.tag == "pipes")
        {
            Destroy(collision.gameObject);
        }

        //if (collision.gameObject.tag == "Destroyer")
        //{
        //    Destroy(collision.gameObject);
        //}
    }
}
