using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StoveCounter;
using static UnityEngine.CullingGroup;

public class ContainerCounter : BaseCounter {


    public event EventHandler OnPlayerGrabbedObject;


    [SerializeField] private KitchenObjectSO kitchenObjectSO;


    public override void Interact(Player player) {
        if (player.HasKitchenObject()) {
            // Player is carrying something
            if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject)) {
                // Player is holding a Plate
                plateKitchenObject.TryAddIngredient(kitchenObjectSO);
            }
        } else {
            // Player is not carrying anything 
            KitchenObject.SpawnKitchenObject(kitchenObjectSO, player);

            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }
    }

}
