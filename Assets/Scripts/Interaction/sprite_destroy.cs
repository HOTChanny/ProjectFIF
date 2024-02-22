using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sprite_destroy : MonoBehaviour
{
    public float limit = 1.2f;
    void Start()
    {
        Destroy(this.gameObject, limit);
    }

    
}
