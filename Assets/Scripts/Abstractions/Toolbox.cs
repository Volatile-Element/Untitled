using UnityEngine;
using System.Collections;

public class Toolbox : Singleton<Toolbox>
{
    protected Toolbox() { }

    public GameManager gameManager = new GameManager();

    private void Awake()
    {  
    }

    static public T RegisterComponent<T>() where T : Component
    {
        return Instance.GetOrAddComponent<T>();
    }
}
