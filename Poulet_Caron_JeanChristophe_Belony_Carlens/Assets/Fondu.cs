using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fondu : MonoBehaviour
{
    private SpriteRenderer fondu;

    public void DemarreSequenceFinDeNiveau(int sceneIndex)
    {
        StartCoroutine(FonduAuNoir(sceneIndex));
    }

    public void DemarreSequenceDebutNiveau()
    {
        fondu = GetComponent<SpriteRenderer>();
        StartCoroutine(FonduAuJeu());
    }

    IEnumerator FonduAuJeu()
    {
        Color col = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        fondu.color = col;
        for (float a = 1.0f; a > 0.0f; a -= 0.05f)
        {
            col.a = a;
            fondu.color = col;
            yield return new WaitForSeconds(.02f);
        }
        col.a = 0.0f;
        fondu.color = col;
    }

    IEnumerator FonduAuNoir(int sceneIndex)
    {
        Color col = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        fondu.color = col;
        for (float a = 0.0f; a < 1.0f; a += 0.05f)
        {
            col.a = a;
            fondu.color = col;
            yield return new WaitForSeconds(.02f);
        }
        col.a = 1.0f;
        fondu.color = col;
        SceneManager.LoadScene(sceneIndex);
    }
}
