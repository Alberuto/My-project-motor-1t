using UnityEngine;
using UnityEngine.SceneManagement;
public class menuController : MonoBehaviour{

    public void SalirJuego(){

        Application.Quit();
    }
    public void Load(string sceneName){
    
        SceneManager.LoadScene("Nivel 1", LoadSceneMode.Single);
    }
}