/*using UnityEngine;

public class NPC_Interact : MonoBehaviour
{
    public DialogueData mojaBiblioteka;
    public float zasiegRozmowy = 3f; 
    private Transform Player;

    void Start()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p != null) Player = p.transform;
    }
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            float dystans = Vector3.Distance(transform.position, Player.position);

            if (dystans <= zasiegRozmowy)
            {
                FindObjectOfType<Dialogi>().RozpocznijDialog(mojaBiblioteka);
            }
        }
    }
}
*/
using UnityEngine;

public class NPC_Interact : MonoBehaviour
{
    public DialogueData mojaBiblioteka;
    public float zasiegRozmowy = 3f;
    private Transform Player;

    void Start()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p != null) Player = p.transform;
    }

    void Update()
    {
        if (Player == null) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            float dystans = Vector3.Distance(transform.position, Player.position);

            if (dystans <= zasiegRozmowy)
            {
                Dialogi system = FindObjectOfType<Dialogi>();
                if (system != null) system.RozpocznijDialog(mojaBiblioteka);
            }
        }
    }
}