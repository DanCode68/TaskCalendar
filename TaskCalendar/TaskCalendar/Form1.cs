using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TaskCalendar
{
    public partial class Form1 : Form
    {
        private Task task, clickTarget;
        private int nextTaskX, nextTaskY, nextTaskIncrement;
        private List<Task> taskList;

        private StreamWriter outFile;
        private string file;

        public Form1()
        {
            InitializeComponent();

            //initialize positions for placing tasks and list to reference them
            nextTaskX = 30;
            nextTaskY = 140;
            nextTaskIncrement = 35;
            taskList = new List<Task>();

            //load saved list of tasks from file
            LoadTasks();

            //report any tasks whose time has passed
            CheckTimes();
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            //store info from text boxes in new task
            task = new Task();

            if (!txtContext.Text.Equals(""))
            {
                task.SetContextString(txtContext.Text);
            }
            if (!txtType.Text.Equals(""))
            {
                task.SetTypeString(txtType.Text);
            }
            task.SetDate(dateTimePicker.Value);
            task.SetTime((int) numTime.Value);
            if (!txtLocation.Text.Equals(""))
            {
                task.SetLocationString(txtLocation.Text);
            }
            if (!txtNote.Text.Equals(""))
            {
                task.SetNoteString(txtNote.Text);
            }

            //put a new task listing in the list
            AddTask(task);
            
            //format list order based on the time associated with each task
            SortTasks();

            //format list item locations
            SetLocations();

            //save list of tasks to file
            SaveTasks();
        }

        private void btnClearFields_Click(object sender, EventArgs e)
        {
            //make task with current time
            Task t = new Task();

            //set fields back to empty/default
            txtContext.Text = "";
            txtType.Text = "";
            dateTimePicker.Value = new DateTime(t.GetYear(), t.GetMonth(), t.GetDay());
            numTime.Value = numTime.Maximum;
            txtLocation.Text = "";
            txtNote.Text = "";
        }

        private void btnRemoveTask_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <taskList.Count; i++)
            {
                if (taskList.ElementAt(i).Checked)
                {
                    Controls.Remove(taskList.ElementAt(i));
                    taskList.RemoveAt(i);
                    i--;
                }
            }

            SetLocations();
            SaveTasks();
        }

        private void txtContext_Enter(object sender, EventArgs e)
        {
            txtContext.SelectAll();
        }

        private void txtType_Enter(object sender, EventArgs e)
        {
            txtType.SelectAll();
        }

        private void numTime_Enter(object sender, EventArgs e)
        {
            numTime.Select(0, 4);
        }

        private void txtLocation_Enter(object sender, EventArgs e)
        {
            txtLocation.SelectAll();
        }

        private void txtNote_Enter(object sender, EventArgs e)
        {
            txtNote.SelectAll();
        }

        private void AddTask(Task t)
        {
            //add task to list
            taskList.Add(t);
            //update text the task shows
            t.ShowText();
            //add task to visible controls in frame
            Controls.Add(t);

            //bind function for clicking on task
            t.MouseUp += new MouseEventHandler(ClickTask);
        }

        private void CheckTimes()
        {
            //make task with current time for comparison
            Task testTask = new Task();

            foreach (Task t in taskList)
            {
                //find any tasks whose associated time comes before the current time
                if (t.CompareTime(testTask) <= 0)
                {
                    //inform the user that the task has expired
                    MessageBox.Show("The due time for the task\n" + t.GetString() + "\nhas passed", "Due Time Passed");
                    //mark expired task for the user to delete
                    //boxList.ElementAt(taskList.IndexOf(t)).Checked = true;
                    t.Checked = true;
                }
            }
        }

        private void ClickTask(object sender, MouseEventArgs e)
        {
            //get the task that was clicked on
            Task t = (Task) sender;

            /*if (e.Button == MouseButtons.Left)
            {
                left click, emulate clicking the associated checkbox
                boxList.ElementAt(taskList.IndexOf(t)).Checked = !(boxList.ElementAt(taskList.IndexOf(t)).Checked);
            }
            else */if (e.Button == MouseButtons.Right)
            {
                //right click, copy task properties into the interactable fields
                CopyTask(t);
            }
        }

        private void CopyTask(Task t)
        {
            //copy task properties into the interactable fields
            txtContext.Text = t.GetContextString();
            txtType.Text = t.GetTypeString();
            dateTimePicker.Value = new DateTime(t.GetYear(), t.GetMonth(), t.GetDay());
            numTime.Value = t.GetTime();
            if (numTime.Value < numTime.Minimum || numTime.Value > numTime.Maximum)
            {
                //make sure the numeric selector doesn't go out of range
                numTime.Value = numTime.Maximum;
            }
            txtLocation.Text = t.GetLocationString();
            txtNote.Text = t.GetNoteString();
        }

        private void LoadTasks()
        {
            file = "TaskCalendar.txt";

            if (File.Exists(file))
            {
                //get all lines of text from saved file
                string[] readStrings = File.ReadAllLines(file);
                //prepare new task to take properties from file
                Task newTask;

                if (readStrings.Length > 0)
                {
                    foreach (string s in readStrings)
                    {
                        //set task properties from delimited string
                        newTask = ParseTask(s, '\t');
                        //add task
                        AddTask(newTask);
                    }

                    //sort and display checkboxes and tasks
                    SortTasks();
                    SetLocations();
                }
            }
        }

        private Task ParseTask(string taskString, char delimiter)
        {
            Task result = new Task();

            //get each property in the string separated by delimiters
            string[] parameters = taskString.Split(delimiter);

            //should be a specific number of parameters, first parameter should have specific length
            if (parameters.Length != 5 || parameters[0].Length != 12)
            {
                //show error if parameters don't have the right format
                MessageBox.Show("", "Error Loading Tasks", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //set each property of new task to property read from file
                result.SetYear(Int32.Parse("" + parameters[0][0] + parameters[0][1] + parameters[0][2] + parameters[0][3]));
                result.SetMonth(Int32.Parse("" + parameters[0][4] + parameters[0][5]));
                result.SetDay(Int32.Parse("" + parameters[0][6] + parameters[0][7]));
                result.SetTime(Int32.Parse("" + parameters[0][8] + parameters[0][9] + parameters[0][10] + parameters[0][11]));
                result.SetContextString(parameters[1]);
                result.SetTypeString(parameters[2]);
                result.SetLocationString(parameters[3]);
                result.SetNoteString(parameters[4]);
            }

            //return customized task if succeeded, default task if failed
            return result;
        }

        private void SaveTasks()
        {
            //make file to save tasks
            file = "TaskCalendar.txt";
            outFile = File.CreateText(file);

            foreach (Task t in taskList)
            {
                //write strings representing properties of each task
                outFile.WriteLine(t.GetTimeStamp() + "\t" + t.GetContextString() + "\t" + t.GetTypeString() + "\t" + t.GetLocationString() + "\t" + t.GetNoteString());
            }

            outFile.Close();
        }

        private void SetLocations()
        {
            //re-initialize dynamic locations
            nextTaskY = 140;

            foreach (Task t in taskList)
            {
                //set location of task in list
                t.SetLocation(nextTaskX, nextTaskY);
                //prepare for next task
                nextTaskY += nextTaskIncrement;
            }
        }

        private void SortTasks()
        {
            //start observing tasks at the end of the task list
            int position = taskList.Count - 1;
            Task target = taskList.ElementAt(position);

            while (position != 0 && target.CompareTime(taskList.ElementAt(position - 1)) < 0)
            {
                //work up the list swapping tasks that are in the wrong order
                SwapTasks(position, position - 1);
                position--;
                target = taskList.ElementAt(position);
            }
        }

        private void SwapTasks(int first, int second)
        {
            //copy tasks at given positions of task list
            Task firstTask = taskList.ElementAt(first), secondTask = taskList.ElementAt(second);

            //remove first out-of-order task, replace with copy of second
            taskList.RemoveAt(first);
            taskList.Insert(first, secondTask);

            //remove second out-of-order task, replace with copy of first
            taskList.RemoveAt(second);
            taskList.Insert(second, firstTask);
        }
    }
}