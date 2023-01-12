using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecepteurCochon : MonoBehaviour
{

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemie"))
        {
            Destroy(collision.gameObject);
        }
    }
}
