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
            _data[i + 8] = 4;
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
        
    }

    public bool IsGameOver()
    {

    }

    public int GetWinner()
    {
        
    }

    public bool IsValidMove()
    {

    }

    private bool IsField(int index)
    {

    }

    private int GetPlayerScoreTitle(int player)
    {

    }

    private bool HasPlayerValidMove(int player)
    {

    }

    public override string ToString()
    {
        return string.Join("", _data) + $"[{_currentPlayer}]";
    }
}
