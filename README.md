# jectionpro-CLI
A command-line interface made to replicate Trello boards. Windows only.

This is NOT a trello API, nor is it related to or affiliated with Trello in any way.

# Installation

To install, download the respective installer for your system in the releases category. 
In the setup wizard, it is reccomended that you install it somewhere that is easy to locate. 
After installation, you'll have to add its location to your %PATH% by doing the following...

- Open settings
- Search for "environment" or "path"
- Click 'edit environment variables for your account' (depending on your installation location, it'd be best to click 'edit the system environment variables' instead)
- In the window that appeared, double click on the cell named 'Path', it should have directories to the right of it. 
After opening the Path variable, you'll see a list of already set path variables. Click 'New' on the top right, then copy and paste your installation directory.
- Close both windows by pressing 'Ok'
- To confirm that this was sucessful, open your terminal and type 'jp'

# Usage

### Create a new project
In your terminal, navigate to a directory of which you want to create a project in.

Type `jp project init <name>` to create a new project. If you want to overwrite an existing project, append the `-f` (also `--force`) options.


### Create and open new pin list

Type `jp list create <name>` to create a new list in the current project.

To display all lists in a project, use `jp list display`. This shows the name and id of every pin list in the project.

To open a pin list for future use, use `jp pin open <id>`, and subsequently `jp pin close` when it is no longer needed.


### Add a new pin to an existing pin list

Type `jp pin create <name>` to create a new pin in the opened pin list. If no pin list is opened, the operation will fail.

To display the pins inside of an opened pin list, use `jp pin display`.

Like the pin list, pins can be opened and closed via `jp pin open <id>` and `jp pin close`. If no pin list is opened, the operation will fail.


### Edit a pin

After opening a pin, its text contents can be edited using `jp pin edit`.

This starts a text editing process inside of the terminal. It currently supports newlines, letters, punctuation, symbols, backspaces, and arrow key movement.

To exit the editor and save your changes, press escape (or ctrl + enter).
