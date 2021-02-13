using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCreateConnect : MonoBehaviour
{

    /// <summary>
    /// connector - ������ ������ ConnectObjectrs.  
    /// �������� � ������ start ��� � ��������
    /// </summary>
    public ConnectObjects connector;

    /// <summary>
    /// ����� ���������, ���� ������ "ConnectObjects" � ���������� ��� ��������� "ConnectObjects"  � connect
    /// </summary>
    private void OnEnable()
    {
        connector = GameObject.Find("ConnectObjects").GetComponent<ConnectObjects>();
    }

    /// <summary>
    /// ����� ��� ������ ����������� �����
    /// </summary>
    public void StartConnectPlus()
    {


        connector.IsConnectToPlus = true;
        connector.FirstObject = gameObject;
        connector.ConnectionInProgress = true;
    }
        

    /// <summary>
    /// ����� ��� ������ ����������� ������
    /// </summary>
    public void StartConnectMinus()
    {
        connector.IsConnectToPlus = false;
        connector.FirstObject = gameObject;
        connector.ConnectionInProgress = true;

    }
}
