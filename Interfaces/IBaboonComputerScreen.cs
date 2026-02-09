using BaboonComputer.Components;

namespace BaboonComputer.Interfaces;

public interface IBaboonComputerScreen
{
    public string Name { get; }

    public void SetText(string text)
    {
        // this field automatically throws the text through the text writer
        BaboonComputerManager.Instance.ScreenText = text;
    }

    public void Update() { }

    public void OnKeyPressed(ComputerKey key) { }
}