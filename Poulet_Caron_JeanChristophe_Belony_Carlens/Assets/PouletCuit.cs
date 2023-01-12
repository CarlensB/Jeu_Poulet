using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PouletCuit : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(SequenceDeMort());
    }

    IEnumerator SequenceDeMort()
    {
        yield return new WaitForSeconds(0.5f);
        EventManager.TriggerEvent("Elimination");
        yield return new WaitForSeconds(3.0f);

    }

}
