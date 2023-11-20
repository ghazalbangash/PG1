using UnityEngine;

[DefaultExecutionOrder(-100)]
public class Settings : MonoBehaviour
{
    [field: SerializeField, Range(0,100)] public float mouseMoveSense { get; private set; }
    [field: SerializeField, Range(0,1)] public float mouseZoomSens { get; private set; }
    [field: SerializeField, Range(0,100)] public float mouseRotateSens { get; private set; }
    
    public static Settings instance { get; private set; }

    //This is called the singleton design pattern, we'll talk more about this if I see you guys again in the winter term.
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
}
