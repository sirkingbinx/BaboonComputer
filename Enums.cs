using System;

namespace BaboonComputer;

/// <summary>
/// Represents a key on the keyboard.
/// </summary>
public enum ComputerKey
{
    // Options
    Opt1 = 1,
    Opt2,
    Opt3,

    // Numbers
    One = 10,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Zero,

    // Special Keys
    Enter = 30,
    Backspace,

    // Letters
    A = 100,
    B, C, D, E, F, G, H, I, J, K, L, M, N,
    O, P, Q, R, S, T, U, V, W, X, Y, Z,
}

internal enum PreprocessedComputerKey
{
    UpArrow,
    DownArrow
}