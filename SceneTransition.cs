using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//precisa do pacote de gerenciamento de cenas para funcionar
using UnityEngine.SceneManagement;

//script que trata da transição entre cenas
public class SceneTransition : MonoBehaviour
{
    //torna editável pelo Unity a cena a ser carregada
    public string sceneToLoad;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !collision.isTrigger)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
