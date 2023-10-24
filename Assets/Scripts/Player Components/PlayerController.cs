using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    #region Singleton 
    private static PlayerController instance = null;
    public static PlayerController Instance
    {
        get { return instance; }
        private set 
        {
            if (instance == null)
            {
                instance = value;
                return;
            }
        }
    }
    #endregion

    #region Fields and Properties
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerWeapons playerWeapons; 
    #endregion

    #region Inputs Methods
    public void OnInputMovement(InputAction.CallbackContext _context)
    {
        playerMovement.MovementDirection = _context.ReadValue<Vector2>(); 
    }

    public void OnFireDirection(InputAction.CallbackContext _context) 
    {
        playerWeapons.FireDirection = _context.ReadValue<Vector2>();
    }
    #endregion

    #region Unity Methods
    private void Awake()
    {
        Instance = this; 
    }
    #endregion

}
