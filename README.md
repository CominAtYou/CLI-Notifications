# CLI-Notifications
A CLI app for displaying Windows notifications

## Usage
cli-notifications.exe --title [title] [args]

### Arguments
`--title`: The title of the notification. If a description isn't provided, this will be the only text in the notification.

`--description`: An optional description for the notification. Requires `--title` to be set in order to use.

`--image`: Adds an inline image to the notification. You'll need to either supply a URL to an image on the internet, or a file:// URI to a local image file.

`--avatar`: Add a profile picture to the notification. Takes either a file:// URI to a local image file, or a URL to an image on the internet.

`--confirmation`: Adds "Yes" and "No" buttons to the notification. If "Yes" is selected, the program will exit with code 0. "No," the program will exit with code 1. If the notification (not a button) is clicked on, the program exits with code 2.

`--clickable`: Set if you want to know when the notification has been clicked on, without "Yes" or "No" buttons. Exits with code 0 when the notification is clicked on. This parameter has no effect if `--confirmation` is passed.

`--uninstall`: Deletes registry entries and the entry in Windows notifiaction settings for this program. Launch the program with this argument when the app utilizing this program is being uninstalled.

## Requirements
Windows 10 build 18362 (1809) or later

## Building
1. [Download the .NET SDK](https://dotnet.microsoft.com/en-us/download)
2. Clone this repo
3. Open the repo in your shell of choice
4. Run `dotnet publish`
5. Find the resulting executable and resources in `bin/Debug/net6.0-windows10.0.22000.0/publish`
