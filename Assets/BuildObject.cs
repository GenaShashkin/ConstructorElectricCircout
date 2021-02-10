
using UnityEngine;
public class BuildObject : MonoBehaviour
{

    [SerializeField] private Camera camera;
    private bool isObjectBuilt;
    /// <summary>
    /// ���������� ��� ������� �����.
    /// ��������� ������� ������ � ���� camera. 
    /// � ��������� ������ � ������ ��� �������������?
    /// ����� ��� �����������. 
    /// </summary>
    private void Awake()
    {
        camera = Camera.main;
        
    }

    /// <summary>
    /// ����� �� Unity, ��������� ��������� ���, ���� ����� ������ �� ���������, 
    /// ������ ����� ��������� �������� �� Unity.
    /// </summary>
    private void OnMouseDrag()
    {
        ChangePosititon();

    }

    /// <summary>
    /// ����� ��� �������������� ������� ������.
    /// </summary>
    private void ChangePosititon()
    {
        if (!isObjectBuilt)
        {
            Vector2 cursor = Input.mousePosition;
            cursor = camera.ScreenToWorldPoint(cursor);
            transform.position = cursor;
        }
    }

    /// <summary>
    /// ����� ��� ��������� �������.
    /// �������� ����� �������, ��� ��� ������� ������.
    /// </summary>
    public void Build()
    {
        Debug.Log("Built was finish");
        isObjectBuilt = true;
    }
}
