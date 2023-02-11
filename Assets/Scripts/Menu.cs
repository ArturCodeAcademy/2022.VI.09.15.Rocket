using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
	private const int MENU_SCENE = 0;
	private const int GAME_SCENE = 1;

	private void Update()
    {
		if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex == GAME_SCENE)
			SceneManager.LoadScene(MENU_SCENE);
    }

	public void ChangeScene(int buildIndex) => SceneManager.LoadScene(buildIndex);

	public void ExitGame() => Application.Quit();
}
