using UnityEngine;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour
{
    public int playerPoints = 0;

    public GameObject textGameObject; // GameObject containing the Text component
    [SerializeField]
    private Text pointsText; // Reference to the UI text element
    public int pointsToAdd = 1;

    void Start()
    {
        // Optional: Initialize the UI text
        /*pointsText = GameObject.FindWithTag("Counter").GetComponent<Text>();
        if (pointsText != null)
        {
            UpdatePointsUI();
        }*/

        // Try to find the Text component on the GameObject
        if (textGameObject != null)
        {
            pointsText = textGameObject.GetComponent<Text>();
            if (pointsText != null)
            {
                UpdatePointsUI();
            }
        }
    }

    void Update()
    {
        // For example, you might use the 'R' key to trigger a restart
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameManager.instance.RestartScene();
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