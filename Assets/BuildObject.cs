
using UnityEngine;
public class BuildObject : MonoBehaviour
{

    [SerializeField] private Camera camera;
    private bool isObjectBuilt;
    /// <summary>
    /// Вызывается при запуске сцены.
    /// Сохраняет главную камеру в поле camera. 
    /// И добовляет собите в кнопку для строительства?
    /// Нужно для оптимизации. 
    /// </summary>
    private void Awake()
    {
        camera = Camera.main;
        
    }

    /// <summary>
    /// Метод от Unity, позволяет выполнять код, если мышка нажата на колайдаре, 
    /// Точнее можно прочитать описание от Unity.
    /// </summary>
    private void OnMouseDrag()
    {
        ChangePosititon();

    }

    /// <summary>
    /// Метод для перетаскивания объекта мышкой.
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
    /// Нужен для постройки объекта.
    /// Вызывать через событие, или при нажатии кнопки.
    /// </summary>
    public void Build()
    {
        Debug.Log("Built was finish");
        isObjectBuilt = true;
    }
}
