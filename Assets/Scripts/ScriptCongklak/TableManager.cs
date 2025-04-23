using System;
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

        for (int i = 0; i < 7; i++)
        {
            _player1Fields[i].text = _table.Data[i].ToString();
            _player2Fields[i].text = _table.Data[i + 8].ToString();
        }
        _player1End.text = _table.Data[7].ToString();
        _player2End.text = _table.Data[15].ToString();

        bool player1Move = _table.CurrentPlayer == 0;
        for (int i = 0; i < 7; i++)
        {
            _player1Buttons[i].interactable = player1Move && _table.Data[i] > 0;
            _player2Buttons[i].interactable = !player1Move && _table.Data[i + 8] > 0;
        }

        if (_table.IsGameOver())
        {
            int winner = _table.GetWinner();
            if (winner == 2)
            {
                _currentPlayerText.text = "Draw";
            }
            else
            {
                _currentPlayerText.text = $"Winner: Player {winner + 1}";
            }
        }
    }

    public void MakeMove(int index)
    {
        if (!_table.Move(index))
        {
            throw new Exception($"Invalid move: {index}");
        }
        UpdateTable();
    }
}
