using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ModelManager : MonoBehaviour
{
    [SerializeField] List<GameObject> inputGameObjects = new List<GameObject>();

    int indexModifier = 0;

    /// <summary>
    /// Prepopulates List with game objects in path /Assets/Resources/Input
    /// </summary>
    void Start()
    {
        Object[] loadedObjectList = Resources.LoadAll("Input", typeof(GameObject));

        foreach (GameObject obj in loadedObjectList)
        {
            var instantiatedObject = Instantiate(obj, transform);
            inputGameObjects.Add(instantiatedObject);                                             // When doing references, don't forget to put INSTANCE of the object, WHICH IS ALREADY INSTANTIATED IN THE SCENE.
            instantiatedObject.SetActive(false);                                                 // In this case, put instantiatedObject in Add method, not obj.
            inputGameObjects[indexModifier].SetActive(true);
        }
    }

    public void ChangeObject(int determine)
    {
        if(determine == 0)
        {
            // Deactivate an object with current index

            Activation(false);

            indexModifier++;
            IndexManipulator();

            // Activate the object with an updated index

            Activation(true);
        }
        else if(determine == 1)
        {
            // Deactivate an object with current index

            Activation(false);

            indexModifier--;
            IndexManipulator();

            // Activate the object with an updated index

            Activation(true);
        }
        else
        {
            return;
        }
    }

    void IndexManipulator()
    {
        if (indexModifier < 0)
        {
            indexModifier = inputGameObjects.Count - 1;
        }
        else if (indexModifier > inputGameObjects.Count - 1)
        {
            indexModifier = 0;
        }
    }

    void Activation(bool isActive)
    {
        var loadedObject = inputGameObjects[indexModifier];
        loadedObject.SetActive(isActive);
    }
}
