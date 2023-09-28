using UnityEngine;

/// <summary>
/// used to add a itself to the gameObject which contains <see cref="T"/> on <see cref="Awake"/>
/// </summary>
public abstract class ScriptAdder<T> : MonoBehaviour where T : MonoBehaviour
{
    protected virtual void Awake()
    {
        //get the component with the given MonoBehaviour
        MonoBehaviour monoBehaviour = GetComponent<T>();

        //if the ballMovement is null, it means we are not on the gameObject with the MonoBehaviour
        if (monoBehaviour != null)
            return; //return because we are on MonoBehaviour

        //find MonoBehaviour and add the  to it
        monoBehaviour = FindObjectOfType<T>(); //find the object of type T
        monoBehaviour.gameObject.AddComponent(GetType()); //GetType() gets the type of the instance
        Destroy(this);
    }
}