using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{

    public void SceneChangeTitle(){SceneManager.LoadScene("TitleScene");}
    public void SceneChangeGame(){SceneManager.LoadScene("GameScene");}
    public void SceneChangeSelect(){SceneManager.LoadScene("SelectScene");}
    public void SceneChangeEnd(){SceneManager.LoadScene("EndScene");}

}
