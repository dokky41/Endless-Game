using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{

    [SerializeField] int createCount;
    [SerializeField] Button buttonPrefab;
    [SerializeField] string buttonName;

    [SerializeField] List<Button> buttons;
    [SerializeField] Transform createPosition;


    // Start is called before the first frame update
    void Start()
    {
        buttons.Capacity = 10;
        CreateButton();
        Register();
    }

    private void CreateButton()
    {
        for(int i =0; i<createCount; i++)
        {
            Button button = Instantiate(buttonPrefab);


            button.transform.SetParent(createPosition);

            switch(i)
            {
                case 0:
                    buttonName = "START";
                    break;
                case 1:
                    buttonName = "SETTING";
                    break;
                case 2:
                    buttonName = "INFO";
                    break;
                case 3:
                    buttonName = "QUIT";
                    break;
            }
            
            button.GetComponentInChildren<TextMeshProUGUI>().text = buttonName;

            buttons.Add(button);
        }

    }

    private void Register()
    {
            
            buttons[0].onClick.AddListener(A);
            buttons[1].onClick.AddListener(B);
            buttons[2].onClick.AddListener(C);
            buttons[3].onClick.AddListener(D);
        
    }

    public void A()
    {
        Debug.Log("A");
    }

    public void B()
    {
        Debug.Log("B");
    }

    public void C()
    {
        Debug.Log("C");
    }

    public void D()
    {
        Debug.Log("D");
    }
}
