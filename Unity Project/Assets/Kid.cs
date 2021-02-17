
using UnityEngine;

public class Kid : MonoBehaviour
{
    [SerializeField] private GameObject parrent;

    public GameObject GetParrent()
    {
        return parrent;
    }

    public ObjectData GetParrentComponentObjectData()
    {
        return parrent.GetComponent<ObjectData>();
    }
}
