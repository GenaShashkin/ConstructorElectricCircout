
using UnityEngine;

public class StartCreateConnect : MonoBehaviour
{

    /// <summary>
    /// connector - ������ ������ ConnectObjectrs.  
    /// �������� � ������ start ��� � ��������
    /// </summary>
    public ConnectObjects connector;

    [SerializeField] private GameObject parrent;

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
}
