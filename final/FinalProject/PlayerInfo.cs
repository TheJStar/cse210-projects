using System;

public class PlayerInfo {
    private int _healthPoints;
    private int _money;
    private int _xCoord;
    private int _yCoord;
    private string _playerSprite = "@P-";
    public PlayerInfo (int healthPoints, int money, int xCoord, int yCoord) {
        _healthPoints = healthPoints;
        _money = money;
        _xCoord = xCoord;
        _yCoord = yCoord;
    }
    public int GetHealthBar () {
        return _healthPoints;
    }
    public void SetHealthBar (int healthPoints) {
        _healthPoints = healthPoints;
    }
    public int[] GetCoords () {
        return [_xCoord, _yCoord];
    }
    public void SetCoords (int xCoord, int yCoord) {
        _xCoord = xCoord;
        _yCoord = yCoord;
    }
    public int GetMoney () {
        return _money;
    }
    public void SetMoney (int money) {
        _money = money;
    }
    public string GetPlayerSprite () {
        return _playerSprite;
    }
}