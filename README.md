## BaboonComputer
This is a small project I'm working on to do a whole bunch of stuff:
- fully replace the functionality of CI with code that wasn't written 5 years ago
- reimplement the color tab to Gorilla Computer (because the color sliders work about 1/5th of the time)
- integrate with other mods to add configuration options, logs, and other cool things

There is no guarantee I'll ever finish this or release it on the modding server, this was made by me for me.

## Writing screens
```cs
using BaboonComputer;
using BaboonComputer.Interfaces;

public class MyComputerScreen : IBaboonComputerScreen
{
	// called anytime a key is pressed, which is realistically the only time you will update screen content
	// an Update() function is also avaliable, but only use it if you have to
	public void OnKeyPressed(ComputerKey key)
	{
		SetText($"key pressed last: {key.ToRealKeyName()}"); // ToRealKeyName() converts the key enum to a string (eg. ComputerKey.One = "1", ComputerKey.E = "E")
	}
}
```
