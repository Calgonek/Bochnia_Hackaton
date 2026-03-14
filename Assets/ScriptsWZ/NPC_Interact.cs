using UnityEngine;
using TMPro;

public class NPC_Interact : MonoBehaviour
{
    public DialogueData mojaBiblioteka;
    public float zasiegRozmowy = 3f;
    public GameObject napisE; 

    private Transform Player;

    void Start()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p != null) Player = p.transform;

        if (napisE != null) napisE.SetActive(false);
    }

    void Update()
    {
        if (Player == null) return;

        float dystans = Vector2.Distance(transform.position, Player.position);


        if (dystans <= zasiegRozmowy)
        {
            if (napisE != null && !napisE.activeSelf) napisE.SetActive(true);

        
            if (Input.GetKeyDown(KeyCode.E))
            {
                Dialogi system = FindObjectOfType<Dialogi>();
                if (system != null) system.RozpocznijDialog(mojaBiblioteka);
            }
        }
        else
        {
          
            if (napisE != null && napisE.activeSelf) napisE.SetActive(false);
        }
    }
}