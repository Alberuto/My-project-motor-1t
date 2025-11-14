using UnityEngine;
using UnityEngine.SceneManagement;
public class menuController : MonoBehaviour{


    private static bool datosBorrados = false;

    void Awake() {
        if (!datosBorrados) {

            PlayerPrefs.DeleteAll();
            datosBorrados = true;
            PlayerPrefs.Save();
        }
    }
    public void SalirJuego(){

        Application.Quit();
    }
    public void Load(string sceneName){
    
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}