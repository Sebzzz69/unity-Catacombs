using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AutoButtonSelect : MonoBehaviour
{
    [SerializeField] Button[] buttons;
    int currentButton;
    private void Start()
    {
        currentButton = 0;
        buttons[currentButton].Select();

        InvokeRepeating("SelectButton", 1f, 1f);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            buttons[currentButton].onClick.Invoke();
        }
    }

    void SelectButton()
    {
        //currentButton = Random.Range(0, buttons.Length);

        currentButton++;
        if(currentButton >=  buttons.Length)
        {
            currentButton = 0;
        }

        buttons[currentButton].Select();
    }

    
}
