using System;

public class Scripture {
    private Reference _reference;
    private List<Word> _words = new List<Word>();
    public Scripture (Reference reference, string text) {
        _reference = reference;
        foreach(string word in text.Split(" "))
        {
            Word w1 = new Word(word);
            _words.Add(w1);
        }
    }
    public void HideRandomWords(int numberToHide) {
        Random random = new Random();
        int i = 0;
        while (i < numberToHide) {
            int randomIndex = random.Next(_words.Count);
            if (!_words[randomIndex].IsHidden()) {
                _words[randomIndex].Hide();
                i++;
            }
        }
    }
        public void UnhideRandomWords(int numberToHide) {
        Random random = new Random();
        int i = 0;
        int j = 0;
        while (i < numberToHide && j != _words.Count) {
            int randomIndex = random.Next(_words.Count);
            if (_words[randomIndex].IsHidden()) {
                _words[randomIndex].Show();
                i++;
            } else {
                if (!_words[j].IsHidden()) {
                    j++;
                }
            }
        }
    }
    public string GetDisplayText () {
        string text = "";
        foreach (Word word in _words) {
            text = text +" "+ word.GetDisplayText();
        }
        return $"{_reference.GetDisplayText()}{text}";
    }
    public bool IsCompletelyHidden () {
        int hiddenCount = 0;
        foreach (Word word in _words) {
            if (word.IsHidden()) {
                hiddenCount++;
            }
        }
        if (hiddenCount == _words.Count) {
            return true;
        } else {
            return false;
        }
    }
}