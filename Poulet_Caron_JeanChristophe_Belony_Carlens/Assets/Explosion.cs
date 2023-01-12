using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject pouletCuit;

    public void OnEndAnimation()
    {
        Destroy(this.gameObject);
        Instantiate(pouletCuit, transform.position, Quaternion.identity);
    }



}
