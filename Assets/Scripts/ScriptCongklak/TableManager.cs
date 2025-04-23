using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TableManager : MonoBehaviour
{
    [Header("Table")]
    [SerializeField] TMP_Text _currentPlayerText;

    [SerializeField] TMP_Text[] _player1Fields;
    [SerializeField] TMP_Text _player1End;
    [SerializeField] TMP_Text[] _player2Fields;
    [SerializeField] TMP_Text _player2End;

    [SerializeField] Button[] _player1Buttons;
    [SerializeField] Button[] _player2Buttons;
    
    private Table _table;

    void Start()
    {
        _table = new Table();
        UpdateTable();
    }

    public void UpdateTable()
    {
        _currentPlayerText.text = $"Current Player: {_table.CurrentPlayer + 1}";
    }
}
