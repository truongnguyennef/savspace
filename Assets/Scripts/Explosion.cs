﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyMyself", 3f);
    }

    void DestroyMyself()
    {
        Destroy(this.gameObject);
    }
}
