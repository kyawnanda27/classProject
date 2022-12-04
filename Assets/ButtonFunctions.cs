using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    [SerializeField] InputField playerNameInput;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        string s = playerNameInput.text;
        PersistentData.Instance.SetName(s);
        SceneManager.LoadScene("Level1");
    }

    public void ToInstructions()
    {
        SceneManager.LoadScene("instructions");
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("menu");
    }

    public void ToSetting()
    {
        SceneManager.LoadScene("settings");
    }

}
