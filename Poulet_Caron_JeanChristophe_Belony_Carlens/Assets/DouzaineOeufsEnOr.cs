using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DouzaineOeufsEnOr : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EventManager.TriggerEvent("FinDuJeu");
    }
}
