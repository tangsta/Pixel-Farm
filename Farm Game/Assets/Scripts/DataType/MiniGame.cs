using UnityEngine.SceneManagement;
using UnityEngine;

[CreateAssetMenu(fileName = "Minigame", menuName = "Minigame")]
public class Minigame : ScriptableObject
{
    public int GameScene;
    public int Gold;

    public int Play()
    {
        SceneManager.LoadScene(GameScene);
        return Gold;
    }
}
