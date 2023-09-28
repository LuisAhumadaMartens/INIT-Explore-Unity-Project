using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class modifier : MonoBehaviour
{
    [SerializeField] EventManager eventManagerObject;

    private enum ModifyType { AddOrRemove, Set };
    [SerializeField] private ModifyType modifyType;
    private enum ObjectType { Coins }; // Add more if you want to have more items types.
    [SerializeField] private ObjectType objectType;
    [SerializeField] private int modifierValue = 1;
    [SerializeField] private bool destroyAfterUse = false;

    void OnCollisionEnter(Collision collision)
    {
        switch (objectType) // Useful if you have more than one object type.
        {
            case ObjectType.Coins:
                if (modifyType == ModifyType.AddOrRemove)
                {
                    eventManagerObject.addCoins(modifierValue);
                    break;
                }
                eventManagerObject.setCoins(modifierValue);
                break;
        }

        if (destroyAfterUse)
            Destroy(gameObject);
    }
}
