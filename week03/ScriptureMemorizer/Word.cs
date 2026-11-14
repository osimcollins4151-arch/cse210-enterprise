public class Word
{
    private string _text;
    private bool _isHidden;

    //Constructor.
    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    // Hide the word.
    public void Hide()
    {
        _isHidden = true;
    }

    // Show the word.
    public void Show()
    {
        _isHidden = false;
    }

    //Check if the word is hidden.
    public bool IsHidden()
    {
        return _isHidden;
    }

    // Return the word or underscores based on its hidden state
    public string GetDisplayText()
    {
        if (_isHidden)
        {
            string hiddenText = "";

            foreach (char character in _text)
            {
                if (char.IsLetterOrDigit(character))
                {
                    hiddenText += "_"; // Preserve whitespace
                }
                else
                {
                    hiddenText += character; // Replace non-whitespace characters with underscores
                }
            }
            return hiddenText;
        }
        else
        {
            return _text;
        }
    }
}