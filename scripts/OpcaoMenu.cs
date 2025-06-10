using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpicaoMenu : MonoBehaviour
{
    public void VoltaAoMenu()
    {
        Debug.Log("clicou");
        SceneManager.LoadScene("Menu");
    }
}
