# About
TreeLaunch 0.8 - Custom Launcher Tool for Windows built using C# WPF

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
TreeLaunch is a launcher application for Windows. It allows you to manage items using groups which are then displayed in a Windows Explorer style tree.
It is designed to be lightweight, flexible and extensible. You can launch any program that can be started from the command line or Windows Run box.

It also provides a time logging feature to provide a history of how long you work with each item in the tree.


# Installation
- Download the latest release https://github.com/dmaccormac/treelaunch/releases
- Unpack setup files and run setup.exe.

TreeLaunch can be uninstalled using 'Programs and Features' in Control Panel.

# Usage
To start TreeLaunch, navigate to the TreeLaunch entry in your Start Menu.

The default tree file *SampleTree.xml* will be loaded when TreeLaunch starts for the first time.
You may edit this file as needed or create a new file elsewhere in the system.

TreeLaunch has the following menu options which can be seen by right-clicking on the Tree.

	- Launch
	- Open XML
	- Edit
	- Refresh
	- View Log
	- Always on Top
	- About


# Configuration

## XML Tree File
TreeLaunch comes with a sample XML file called SampleTree.xml which is loaded by default when the program starts.

Below is a simple example of the XML format used by TreeLaunch.

	<Tree>
		<Group Name="My First Group">
			<Item Name="Notepad" Command="notepad.exe" />
			<Item Name="Calculator" Command="calc.exe" />
		</Group>
	</Tree>
	
You can create as many items and groups as needed using the example shown above. "Name" is the only attribute required by the Group tag.

The 'Item' tag has four attributes as follows:

	Attribute	Required? 	Info
	---------	---------	------
	Name		Required 	Shown in Tree as Item Name.
	Command		Required 	Command to be launched.
	Parameters	Optional	Additional parameters to pass to command.
	Icon		Optional	Path to PNG icon file to be used for the item.




# Notes
