//Copyright (C) 2015 Dan MacCormac <info@danmac.co>

//This program is free software: you can redistribute it and/or modify 
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, either version 3 of the License, or
//(at your option) any later version.

//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//GNU General Public License for more details.

//You should have received a copy of the GNU General Public License
//along with this program.  If not, see <http://www.gnu.org/licenses/>.


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TreeLaunch
{
    class Session
    {
        public string name;
        public string command;
        public string parameters;


        public Session(string name, string command, string parameters) 
        {
            this.name = name;
            this.command = command;
            this.parameters = parameters;

        }

        public Session(string name, string command)
        {
            this.name = name;
            this.command = command;

        }

        public void Launch()
        {

            // http://stackoverflow.com/questions/18405638/how-to-wait-until-mstsc-exe-exits
                        

            try //mstsc method
            {

                var process = new Process
                {
                    StartInfo = new ProcessStartInfo(command, parameters) { UseShellExecute = false, RedirectStandardOutput = true }
                };

                process.Start();
                WriteLog("[" + DateTime.Now + "] Start " + command + " (" + name + ")");

                var outputResultPromise = process.StandardOutput.ReadToEndAsync();
                outputResultPromise.ContinueWith(o => WriteLog("[" + DateTime.Now + "] End " + command + " (" + name + ")"));

            }

            catch (Exception e) 
            {



                if (e is System.ComponentModel.Win32Exception) //older method 
                {
                    Process p = new Process();
                    WriteLog("[" + DateTime.Now + "] Start " + command + " (" + name + ")");
                    p = Process.Start(command, parameters);


                    //Wait for Process to Exit
                    try
                    {
                        p.EnableRaisingEvents = true; //Receive Callback on Exited Event
                        p.Exited += new EventHandler(ProcessExited); //Method ProcessExited() called on Exit

                    }

                    catch //issues with process.start(url) -- check EnableRaisingEvents alternative
                    {
                    }


                }

                

            }





        }

        public string WriteLog(string s)
        {

            //Try to append passed string parameter to log file.
            try
            {

                string filename = Properties.Settings.Default.LogFile;
                File.AppendAllText(filename, s + Environment.NewLine);

            }

            //Handle any expception by returning error string
            catch (Exception e)
            {
                return ("Problem writing log file: " + e.ToString());

            }

            //All OK
            return ("Successfully wrote to log file.");

            

        }

        public void ProcessExited(object sender, System.EventArgs e)
        {
            WriteLog("[" + DateTime.Now + "] End " + command + " (" + name + ")");

        }


    }
}
