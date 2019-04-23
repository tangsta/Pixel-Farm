using UnityEngine.SceneManagement;
using UnityEngine;

[CreateAssetMenu(fileName = "Minigame", menuName = "Minigame")]
public class MiniGame : ScriptableObject
{
    public int GameScene;
    public int Gold;

    public int Play()
    {
        SceneManager.LoadScene(GameScene);
        return Gold;
    }
}
