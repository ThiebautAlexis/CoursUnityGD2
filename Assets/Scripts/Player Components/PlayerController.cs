using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem; 

public class PlayerController : MonoBehaviour
{
    #region Fields and Properties
    [SerializeField] private PlayerMovement playerMovement; 
    #endregion

    #region Inputs Methods
    public void OnInputMovement(InputAction.CallbackContext _context)
    {
        playerMovement.MovementDirection = _context.ReadValue<Vector2>(); 
    }
    #endregion

    #region Unity Methods
    #endregion

}
