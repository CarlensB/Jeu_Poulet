using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MoteurJeu : MonoBehaviour
{

    private UnityAction onElimination;
    private UnityAction onLevelEnd;
    private UnityAction onGameEnd;
    private Fondu fondu;


    private void Awake()
    {
        onElimination = new UnityAction(Mort);
        onLevelEnd = new UnityAction(ChangerNiveau);
        onGameEnd = new UnityAction(finirJeu);
        fondu = Object.FindObjectOfType<Fondu>();

    }

    void ChangerNiveau()
    {
        int sceneActuel = SceneManager.GetActiveScene().buildIndex;
        sceneActuel += 1;
        fondu.DemarreSequenceFinDeNiveau(sceneActuel);
        
    }

    void Mort()
    {
        fondu.DemarreSequenceFinDeNiveau(0);
    }

    void finirJeu()
    {
        Debug.Log("Bravo, vous avez fini le jeu");
    }

    public void OnEnable()
    {
        EventManager.StartListening("Elimination", onElimination);
        EventManager.StartListening("FinDuNiveau", onLevelEnd);
        EventManager.StartListening("FinDuJeu", onGameEnd);
    }

    public void OnDisable()
    {
        EventManager.StopListening("Elimination", onElimination);
        EventManager.StopListening("FinDuNiveau", onLevelEnd);
        EventManager.StopListening("FinDuJeu", onGameEnd);
    }

    void Start()
    {
        fondu.DemarreSequenceDebutNiveau();
    }

}
