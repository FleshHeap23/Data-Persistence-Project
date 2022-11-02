using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public TMP_InputField nameInput;


    // Start is called before the first frame update
    void Start()
    {
        if (DataManager.Instance.playerName != null)
        {
            nameInput.text = DataManager.Instance.playerName;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        DataManager.Instance.playerName = nameInput.text;
        SceneManager.LoadScene("main");
    }

  

   

    public void Exit()
    {
        DataManager.Instance.SaveData();
        Application.Quit();
    }

}
