using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmetteurCochon : MonoBehaviour
{
    public GameObject recepteur;
    public GameObject cochon;
    private Vector3 direction;
    private WaitForSeconds refreshIntervalWait = new WaitForSeconds(1.0f);


    // Start is called before the first frame update
    void Start()
    {
        direction = (recepteur.transform.position - transform.position).normalized;
        StartCoroutine("spawnCochons");
    }

    // Update is called once per frame
    void Update()
    {
    }


    IEnumerator spawnCochons()
    {
        while (true)
        {
            yield return refreshIntervalWait;

            GameObject instCochon = Instantiate(cochon, transform.position, Quaternion.identity);
            Cochon scriptCochon = instCochon.GetComponent<Cochon>();
            scriptCochon.vitesse = Random.Range(0.5f, 5.0f);
            scriptCochon.spawn(direction);

        }


        
    }

}
