using UnityEngine;

/// <summary>
/// used to add a itself to the gameObject which contains <see cref="T"/> on <see cref="Awake"/>
/// </summary>
/// <typeparam name="T">the component that is on the gameObject an instance type is added to</typeparam>
public abstract class ScriptAdder<T> : MonoBehaviour where T : Component //make sure the type parameter T is derived from a Component
{
    protected virtual void Awake()
    {
        //get the component with the given component
        Component component = GetComponent<T>();

        //if the ballMovement is null, it means we are not on the gameObject with the component
        if (component != null)
            return; //return because we are on the component

        //find the component and add the  to it
        component = FindObjectOfType<T>(); //find the object of type T
        component.gameObject.AddComponent(GetType()); //GetType() gets the type of the instance
        Destroy(this); //remove the instance from the current script because we don't belong here >:3
    }
}
