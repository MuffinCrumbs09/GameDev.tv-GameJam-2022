using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetLevel : MonoBehaviour{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)){
            int level = GameObject.Find("LevelManager").GetComponent<LevelManager>().level;
            SceneManager.LoadScene(level);

            if(level > 1){
                GameObject.Find("LevelManager").GetComponent<LevelManager>().level--;
            }
        }
    }
}