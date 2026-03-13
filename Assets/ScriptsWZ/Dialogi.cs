using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class Dialogi : MonoBehaviour
{
    public TextMeshProUGUI poleNazwy;
    public TextMeshProUGUI poleTekstu;
    public GameObject panelDialogu;

    private Queue<string> kolejkaZdan = new Queue<string>();

    public void RozpocznijDialog(DialogueData dane)
    {
        panelDialogu.SetActive(true);
        poleNazwy.text = dane.nazwaNPC;
        kolejkaZdan.Clear();

        foreach (string zdanie in dane.kwestie)
        {
            kolejkaZdan.Enqueue(zdanie);
        }

        NastepneZdanie();
    }

    public void NastepneZdanie()
    {
        if (kolejkaZdan.Count == 0)
        {
            KoniecDialogu();
            return;
        }

        poleTekstu.text = kolejkaZdan.Dequeue();
    }

    void KoniecDialogu()
    {
        panelDialogu.SetActive(false);
    }
}