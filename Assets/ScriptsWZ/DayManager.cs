using UnityEngine;

public class DayManager : MonoBehaviour
{
    public static DayManager Instance;
    public int currentDay = 1;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void NextDay()
    {
        currentDay++;
        Debug.Log("Nasta³ dzieñ: " + currentDay);
    }
}