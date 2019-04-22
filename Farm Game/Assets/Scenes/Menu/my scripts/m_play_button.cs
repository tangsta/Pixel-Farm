using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class m_play_button : MonoBehaviour
{
  public void LoadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }


}
