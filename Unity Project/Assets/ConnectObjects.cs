using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ConnectObjects : MonoBehaviour
{   /// <summary>
    /// ConnectionjInProgress  - ����, ������������,  ��� �� ������ ����������� ��������;                                  
    /// </summary>
    public bool ConnectionInProgress;
    /// <summary>
    /// FirstObject, SecondObject - ������ ���������� ���� GameObject � ������������ ��������.
    /// </summary>
    public GameObject FirstObject, SecondObject;
    /// <summary>
    /// IsConnectToPlus - ����, ��� ��������, ��� �� ����������� � �����.
    /// </summary>
    public bool IsConnectToPlus;
    /// <summary>
    /// camera - ������ ������� ������.
    /// </summary>
    private Camera camera;

    /// <summary>
    /// �������� �� ����� �������� ����� ������ � ���������� �������� � camera
    /// </summary>
    private void Awake()
    {
        camera = Camera.main;
    }

    /// <summary>
    ///  ������ ���� �������� ������
    /// </summary>
    private void Update()
    {
        CreateConnection();
    }

    /// <summary>
    /// ����� ��� �������� �����������.
    /// 
    /// ���� ��� �����������, ��:
    ///     ��������� ���� �� ������ ������ ��� �����������, ���� ��� ��:
    ///         ��������� ������ �� ������ ���, ���� �� ��:
    ///             ��������� ��� �� ������� �������  � ��������� ��� (minus or plus) � ������� � ������� �� �����.
    /// </summary>
    private void CreateConnection()
    {
        if (ConnectionInProgress)
        {
            if (!SecondObject)
            {
                if (Input.GetKey(KeyCode.Mouse0))
                {            
                    RaycastHit2D hit2D = Physics2D.Raycast(GetPositionCursor(), Vector3.forward);
                    
                    if (hit2D.collider.CompareTag("plus") && IsConnectToPlus)
                    {
                        Debug.Log("Connected Plus!");
                        SecondObject = hit2D.collider.gameObject;
                        SetDefaultVolums();
                    }

                    if (hit2D.collider.CompareTag("minus") && !IsConnectToPlus)
                    {
                        Debug.Log("Connected Minus!");
                        SecondObject = hit2D.collider.gameObject;
                        SetDefaultVolums();
                    }


                }
            }
        }
    }
    /// <summary>
    /// �������� ���������� �������.
    /// </summary>
    /// <returns>����������� ���������� �������</returns>
    private Vector2 GetPositionCursor()
    {
        Vector2 cursor = Input.mousePosition;
        cursor = camera.ScreenToWorldPoint(cursor);
        return cursor;
    }

    private void SetDefaultVolums()
    {
        FirstObject = null;
        SecondObject = null;
        ConnectionInProgress = false;
        IsConnectToPlus = false;
    }
}
