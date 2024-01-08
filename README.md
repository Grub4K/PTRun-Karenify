# PowerToys Run: Karenify Plugin

Do you wish you were a middle-aged white mom with a [hip, modern haircut](https://www.hottesthaircuts.com/wp-content/uploads/2020/10/Karen-Haircut-10.jpg), but you just can't find the manager?

ThEn ThIs Is ThE pLuGiN fOr YoU!

## Requirements

- PowerToys (tested with v0.76.2)

## Installation

Install:
1. Download the [latest release](https://github.com/Grub4K/PTRun-Karenify/releases/latest)
2. Close PowerToys
3. Extract the `Karenify` folder inside it to `%LocalAppData%\Microsoft\PowerToys\PowerToys Run\Plugins`
4. Start PowerToys

### Usage

1. Open PowerToys Run (default: `<Alt>` + `<Space>`)
2. Type the direct activation command (default: `k`) and a space
3. Continue typing whatever you want to karenify
4. Select one of the entries, then press `<Enter>` to copy that into clipboard

## Building

1. Clone this repository
2. The build process takes the reference libraries from `%ProgramFiles%/PowerToys/`. If the install location differs or you want to build against another version, copy the following files to the `Karenify/lib/` directory:
	- `PowerToys.Common.UI.dll`
	- `PowerToys.ManagedCommon.dll`
	- `Wox.Plugin.dll`
3. Build the project with `dotnet publish -c:Release`, or equivalent
