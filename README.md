# About
TreeLaunch 0.8 - Custom Launcher Tool for Windows <http://go.danmac.co/treelaunch>

Copyright (C) 2015 Dan MacCormac <info@danmac.co>

This program is free software: you can redistribute it and/or modify 
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.


# Overview
TreeLaunch is a custom launcher tool for Windows. It allows you to manage items into groups which are then displayed in a Windows Explorer style tree. It is designed to be lightweight, flexible and portable. 

You can launch any program that can be started from the command line or Windows Run box. It also provides a time logging feature which keeps a history of how long you work with each item in the tree.

TreeLaunch was written in C# and uses WPF and .NET 4.5 Framework. 

# Installation
- Download the latest release https://github.com/dmaccormac/treelaunch/releases
- Unpack setup files and run setup.exe.

TreeLaunch can be uninstalled using 'Programs and Features' in Control Panel.

# Usage
To start TreeLaunch, navigate to the TreeLaunch entry in your Start Menu.

The default tree file *SampleTree.xml* will be loaded when TreeLaunch starts for the first time.
You may edit this file as needed or create a new file and save it elsewhere.

TreeLaunch has the following menu options which can be seen by right-clicking on the Tree.

## Launch
Start the selected Item. You can also launch an item by double-clicking on it.

## Open XML
Choose an XML tree file to open. This setting will be saved by TreeLaunch for the next time you open the program.
 
## Edit XML
Open the current XML tree file in the default editor (Windows Notepad).

## Refresh
Refresh the current tree if you have made any changes to the XML tree file. The tree should automatically refresh itself in most cases.

## View Log
View the TreeLaunch.log file. Each time an item is started or closed it is recorded in the log file along with a timestamp. 

## Always on Top
Select the *Always on Top* option to keep the TreeLaunch window above all other windows.

## About
Display the *About* message.

# Configuration

## XML Tree File
TreeLaunch uses an XML document to store entries in the Tree. 

*SampleTree.xml* which comes pre-loaded with TreeLaunch shows several useful examples including remote connections such as Microsoft Remote Desktop, SSH and VPN.

Below is a very simple example of the XML format used by TreeLaunch. 

	<Tree>
		<Group Name="My First Group">
			<Item Name="Notepad" Command="notepad.exe" />
			<Item Name="Calculator" Command="calc.exe" />
		</Group>
	</Tree>
	
You can create as many items and groups as needed using the XML format above. A more detailed explanation of the XML tags and attributes used by TreeLaunch is given below. 
 

## XML Tags
TreeLaunch uses three XML tags to store the tree information: *\<Tree\>*, *\<Group\>* and *\<Item\>*. 

### \<Tree\> Tag
The entire tree must be enclosed in *Tree* tags. No additional attributes required.

### \<Group\> Tag
Used to group several *Item* tags together. It can be named using the required *Name* attribute and an optional icon can be displayed using the *Icon* attribute.

	Attribute	Required? 	Info
	---------	---------	------
	Name		Required 	Shown in Tree as Group Name.
	Icon		Optional	Path to PNG icon file to be used for the Group.

### \<Item\> Tag
The *Item* tag is used to create items which are essentially commands to be executed, usually along with additional customized parameters, and an optional Icon.

The *Item* tag has four attributes as follows:

	Attribute	Required? 	Info
	---------	---------	------
	Name		Required 	Shown in Tree as Item Name.
	Command		Required 	Command to be launched.
	Parameters	Optional	Additional parameters to pass to command.
	Icon		Optional	Path to PNG icon file to be used for the item.

## Icons
Custom icons can be added to *Group* and *Item* objects in the Tree. TreeLaunch comes with four default icons included in the program installation folder:

- folder.png
- computer.png
- tool.png
- website.png

These PNG icons are size 16 x 16. You can add your own icons as needed using the *Icon* attribute and the path to your own custom icons. 

# Notes
- The LogFile feature is experimental. It is known to currently have issues with Google Chrome.
