
using UnityEditor.SearchService;

using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateObjectForBuild : MonoBehaviour
{
    /// <summary>
    /// При вызове метода создаётся объект, 
    /// и изменяются его координаты на нулевые.
    /// </summary>
    /// <param name="gameObjectForBuild"> объект для создания </param>
    public void CreateObject(GameObject gameObjectForBuild)
    {
        GameObject gameObject;

        gameObject = Instantiate(gameObjectForBuild);
        gameObject.transform.position = new Vector3(0, 0, 0);
    }

    public void Restart()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
}
