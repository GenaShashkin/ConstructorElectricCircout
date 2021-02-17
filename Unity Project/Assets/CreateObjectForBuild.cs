
using UnityEditor.SearchService;

using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateObjectForBuild : MonoBehaviour
{
    /// <summary>
    /// ��� ������ ������ �������� ������, 
    /// � ���������� ��� ���������� �� �������.
    /// </summary>
    /// <param name="gameObjectForBuild"> ������ ��� �������� </param>
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
