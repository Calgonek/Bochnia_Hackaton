using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "BibliotekaDialogow", menuName = "Dialogi/Biblioteka")]
public class DialogueData : ScriptableObject
{
    [Header("Dialogi Gracza")]
    public string playerDialog = "Dziwnie si� czuj�...";

    [Header("Dialogi NPC")]
    public string janDialog = "Musz� wypi� kaw�.";
    public string marekDialog = "Co tu si� dzieje?";
    public string annaDialog = "Nie mam teraz czasu.";
    public string PobierzTekst(string postac)
    {
        switch (postac.ToLower())
        {
            case "player": return playerDialog;
            case "jan": return janDialog;
            case "marek": return marekDialog;
            case "anna": return annaDialog;
            default: return "brak dialogu";
        }
    }

    // TODO
    public List<string> kwestie;
    public string nazwaNPC;
}