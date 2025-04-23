public class Table
{
    private int[] _data;
    private int _currentPlayer;

    public int[] Data => _data;
    public int CurrentPlayer => _currentPlayer;

    public Table()
    {
        _data = new int[16];
        for (int i = 0; i < 7; i++)
        {
            _data[i] = 7;
            _data[i + 8] = 7;
        }
        _currentPlayer = 0;
    }

    public Table(Table table)
    {
        _data = new int[16];
        for (int i = 0; i < _data.Length; i++)
        {
            _data[i] = table.Data[i];
        }
        _currentPlayer = table.CurrentPlayer;
    }

    public bool Move(int index)
    {
        if (!IsValidMove(index))
        {
            return false;
        }
        int pickIndex = index + _currentPlayer * 8;
        int placeCount = _data[pickIndex];

        int tileIndex = -1;
        _data[pickIndex] = 0;
        for (int i = 0; i < placeCount; i++)
        {
            tileIndex = (pickIndex + i + 1) % 16;
            if (tileIndex == 7 + (1 - _currentPlayer) * 8)
            {
                placeCount++;
                continue;
            }
            _data[tileIndex]++;
        }

        int currentPlayerScoreTile = GetPlayerScoreTitle(_currentPlayer);
        if (tileIndex == currentPlayerScoreTile)
        {
            if (!HasPlayerValidMove(_currentPlayer))
            {
                _currentPlayer = 1 - _currentPlayer;
            }
            return true;
        }

        if (IsField(tileIndex) && _data[tileIndex] == 1)
        {
            int stealTile = 14 - tileIndex;
            _data[currentPlayerScoreTile] += _data[stealTile];
            _data[stealTile] = 0;
        }

        if (HasPlayerValidMove(1 - _currentPlayer))
        {
            _currentPlayer = 1 - _currentPlayer;
        }
        return true;
    }

    public bool IsGameOver()
    {
        return !HasPlayerValidMove(_currentPlayer) && !HasPlayerValidMove(1 - _currentPlayer);
    }

    public int GetWinner()
    {
        if (_data[7] == _data[15])
        {
            return 2;
        }
        return _data[7] > _data[15] ? 0 : 1;
    }

    public bool IsValidMove(int index)
    {
        if (index < 0 || index > 7)
        {
            return false;
        }
        if (_data[index + _currentPlayer * 8] == 0)
        {
            return false;
        }
        return true;
    }

    private bool IsField(int index)
    {
        return index != 7 && index != 15;
    }

    private int GetPlayerScoreTitle(int player)
    {
        return 7 + player * 8;
    }

    private bool HasPlayerValidMove(int player)
    {
        for (int i = 0; i < 7; i++)
        {
            if (_data[i + player * 8] > 0)
            {
                return true;
            }
        }
        return false;
    }

    public override string ToString()
    {
        return string.Join("", _data) + $"[{_currentPlayer}]";
    }
}
