using System;

public class Word {
    private string _text;
    private bool _isHidden = false;
    public Word (string text) {
        _text = text;
    }
    public void Show() {
        _isHidden = false;
    }
    public void Hide() {
        _isHidden = true;
    }
    public bool IsHidden() {
        return _isHidden;
    }
    public string GetDisplayText () {
        string word = "";
        foreach (char letter in _text) {
            if (IsHidden() == true) {
                word = word + "_";
            }else {
                word = word + letter;
            }
        }
        return word;
    }
}