using UnityEngine;

public class VictoryUI : MonoBehaviour
{
    public GameObject victoryText;

    public void ShowVictory()
    {
        victoryText.SetActive(true);
    }
}