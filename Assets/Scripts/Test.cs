using UnityEngine;
using UnityEngine.Events;

public class Test : MonoBehaviour
{
    public UnityEvent eventoTest; 
    void Start()
    {
    }

    void Update()
    {
        if (eventoTest != null)
        {
            eventoTest.Invoke();
        }
        
        eventoTest?.Invoke();
    }
}
