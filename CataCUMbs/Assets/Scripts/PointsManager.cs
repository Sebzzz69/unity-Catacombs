using UnityEngine;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour
{
    public int playerPoints = 0;
    public Text pointsText; // Reference to the UI text element

    void Start()
    {
        // Optional: Initialize the UI text
        pointsText = GameObject.FindWithTag("Counter").GetComponent<Text>();
        if (pointsText != null)
        {
            UpdatePointsUI();
        }
    }

    public void CollectPoints(int pointsToAdd)
    {
        playerPoints += pointsToAdd;

        // Optional: Update the UI text
        if (pointsText != null)
        {
            UpdatePointsUI();
        }
    }

    void UpdatePointsUI()
    {
        pointsText.text = "Points: " + playerPoints.ToString();
        Debug.Log("Updated");
    }
}