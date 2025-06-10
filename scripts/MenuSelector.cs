using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuSelector : MonoBehaviour
{
    public RectTransform cursorImage; 
    public RectTransform[] menuOptions; 
    public float yOffset = -80f; 

    private int currentIndex = 0;

    void Start()
    {
        MoveCursor();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow)|| Input.GetKeyDown(KeyCode.S))
        {
            currentIndex = (currentIndex + 1) % menuOptions.Length;
            MoveCursor();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetKeyDown(KeyCode.W))
        {
            currentIndex = (currentIndex - 1 + menuOptions.Length) % menuOptions.Length;
            MoveCursor();
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            SelectOption();
        }
    }

    void MoveCursor()
    {
        Vector3 targetPos = menuOptions[currentIndex].position;
        cursorImage.position = new Vector3(cursorImage.position.x, targetPos.y, targetPos.z);
    }

    void SelectOption()
    {
        switch (currentIndex)
        {
            case 0:
                SceneManager.LoadScene("Fase1"); 
                break;
            case 1:
                SceneManager.LoadScene("Opcoes");
                Debug.Log("Opções selecionado");
                break;
            case 2:
                Application.Quit();
                break;
        }
    }
}