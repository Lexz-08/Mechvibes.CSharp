# Mechvibes.CSharp
## Description
A C# remake of Mechvibes, with compatibility of the soundpacks so that you can load your soundpacks into both programs.

## Download
[Standalone](https://github.com/Lexz-08/Mechvibes.CSharp/releases/download/mechvibes-remake/Mechvibes.CSharp.exe)

## SoundPack Format (`config.json` format)
You can use the key codes provided to create a custom soundpack manually through a text-editor or code-editor.

`config.json` SoundPack Format:
```json
{
    "id": "custom-sound-pack-1612728813651",
    "name": "SOUNDPACK_NAME",
    "key_define_type": "multi",
    "includes_numpad": "BOOLEAN",
    "sound": "FIRST_SOUNDPACK_KEY",
    "defines": {
        "KEY_CODE": "AUDIO_FILE",
    },
}
```
Definitions:
  * `SOUNDPACK_NAME`: The name of your custom Mechvibes soundpack.
  * `BOOLEAN`: `true` if you're including key presses of the numpad in your soundpack, otherwise `false`.
  * `FIRST_SOUNDPACK_KEY`: The first audio file in your soundpack. [`Mechvibes`](https://github.com/hainguyents13/mechvibes) uses this for `single-key` soundpacks.
  * `KEY_CODE`: The key code (you can use the list below for help) that will bind the matching key to the `AUDIO_FILE` specified with it.
  * `AUDIO_FILE`: The audio file to play when the key that matches the specified `KEY_CODE` is pressed.

## Key Code List (Key Code <-> Key on Keyboard, helps to translate the information for the key binds)
| Key Code | Keyboard Key    |
|----------|-----------------|
| 1        | Escape          |
| 59       | F1              |
| 60       | F2              |
| 61       | F3              |
| 62       | F4              |
| 63       | F5              |
| 64       | F6              |
| 65       | F7              |
| 66       | F8              |
| 67       | F9              |
| 68       | F10             |
| 87       | F11             |
| 88       | F12             |
| 41       | `               |
| 2        | 1               |
| 3        | 2               |
| 4        | 3               |
| 5        | 4               |
| 6        | 5               |
| 7        | 6               |
| 8        | 7               |
| 9        | 8               |
| 10       | 9               |
| 11       | 0               |
| 12       | -               |
| 13       | =               |
| 14       | Backspace       |
| 15       | Tab             |
| 58       | Caps Lock       |
| 30       | A               |
| 48       | B               |
| 46       | C               |
| 32       | D               |
| 18       | E               |
| 33       | F               |
| 34       | G               |
| 35       | H               |
| 23       | I               |
| 36       | J               |
| 37       | K               |
| 38       | L               |
| 50       | M               |
| 49       | N               |
| 24       | O               |
| 25       | P               |
| 16       | Q               |
| 19       | R               |
| 31       | S               |
| 20       | T               |
| 22       | U               |
| 47       | V               |
| 17       | W               |
| 45       | X               |
| 21       | Y               |
| 44       | Z               |
| 26       | [               |
| 27       | ]               |
| 43       | ]               |
| 39       | ;               |
| 40       | '               |
| 28       | Enter           |
| 51       | ,               |
| 52       | .               |
| 53       | /               |
| 57       | Space           |
| 3639     | Print Screen    |
| 70       | Scroll Lock     |
| 3653     | Pause           |
| 3666     | Insert          |
| 3667     | Delete          |
| 3655     | Home            |
| 3663     | End             |
| 3657     | Page Up         |
| 3665     | Page Down       |
| 57416    | Up (↑)          |
| 57419    | Left (←)        |
| 57421    | Right (→)       |
| 57424    | Down (↓)        |
| 42       | L-Shift         |
| 54       | R-Shift         |
| 29       | L-Control       |
| 3613     | R-Control       |
| 56       | L-Alt           |
| 3640     | R-Alt           |
| 3675     | L-Win           |
| 3676     | R-Win           |
| 3677     | Apps (Menu)     |
| 61010    | Insert (Win)    |
| 61011    | Delete (Win)    |
| 60999    | Home (Win)      |
| 61007    | End (Win)       |
| 61001    | Page Up (Win)   |
| 61009    | Page Down (Win) |
| 61000    | Up (↑) (Win)    |
| 61003    | Left (←) (Win)  |
| 61005    | Right (→) (Win) |
| 61008    | Down (↓) (Win)  |
| 69       | Num Lock        |
| 3637     | Divide          |
| 55       | Multiply        |
| 74       | Subtract        |
| 78       | Add             |
| 3612     | Enter           |
| 83       | Decimal         |
| 79       | NumPad 1        |
| 80       | NumPad 2        |
| 81       | NumPad 3        |
| 75       | NumPad 4        |
| 76       | NumPad 5        |
| 77       | NumPad 6        |
| 71       | NumPad 7        |
| 72       | NumPad 8        |
| 73       | NumPad 9        |
| 82       | NumPad 0        |
