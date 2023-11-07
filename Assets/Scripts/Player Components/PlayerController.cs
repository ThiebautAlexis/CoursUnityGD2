using System;
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
    [SerializeField] private new Camera camera; 
    #endregion 

    #region Inputs Methods
    public void OnInputMovement(InputAction.CallbackContext _context)
    {
        playerMovement.MovementDirection = _context.ReadValue<Vector2>(); 
    }

    public void OnFireDirection(InputAction.CallbackContext _context) 
    {
        Vector2 _mousePosition = _context.ReadValue<Vector2>();
        
        Vector2 _mousePositionToWorld = camera.ScreenToWorldPoint(_mousePosition);
        playerWeapons.FireDirection = (_mousePositionToWorld - (Vector2)transform.position);
    }
    #endregion

    #region Unity Methods
    private void Awake()
    {
        Instance = this; 
    }
    #endregion

    #region Score
    private static int score = 0;
    public static event Action<int> UpdateScore;

    public static void AddScore(int _points)
    {
        score += _points;
        UpdateScore?.Invoke(score);
    }
    #endregion

}
