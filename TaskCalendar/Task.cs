using System;
using System.Drawing;
using System.Windows.Forms;

namespace TaskCalendar
{
    class Task : CheckBox
    {
        private string[] infoStrings; //context, type, location, note

        private int[] timeInts; //year, month, day, time of day

        private DateTime current;

        public Task()
        {
            infoStrings = new string[5];
            timeInts = new int[4];

            SetContextString("null");
            SetTypeString("null");
            SetLocationString("null");
            SetNoteString("null");

            current = DateTime.Now;
            SetYear(current.Year);
            SetMonth(current.Month);
            SetDay(current.Day);
            infoStrings[4] = "" + current.Hour + current.Minute;
            SetTime(Int32.Parse(infoStrings[4]));

            AutoSize = true;
            Text = GetString();
        }

        public Task(string context, string kind, string location, string notes, int year, int month, int day, int time)
        {
            infoStrings = new string[5];
            timeInts = new int[4];

            SetContextString(context);
            SetTypeString(kind);
            SetLocationString(location);
            SetNoteString(notes);

            SetYear(year);
            SetMonth(month);
            SetDay(day);
            SetTime(time);

            AutoSize = true;
            Text = GetString();
        }

        public string GetContextString()
        {
            return infoStrings[0];
        }

        public void SetContextString(string context)
        {
            infoStrings[0] = context;
        }

        public string GetTypeString()
        {
            return infoStrings[1];
        }

        public void SetTypeString(string kind)
        {
            infoStrings[1] = kind;
        }

        public string GetLocationString()
        {
            return infoStrings[2];
        }

        public void SetLocationString(string location)
        {
            infoStrings[2] = location;
        }

        public string GetNoteString()
        {
            return infoStrings[3];
        }

        public void SetNoteString(string note)
        {
            infoStrings[3] = note;
        }

        public int GetYear()
        {
            return timeInts[0];
        }

        public void SetYear(int year)
        {
            timeInts[0] = year;
        }

        public int GetMonth()
        {
            return timeInts[1];
        }

        public void SetMonth(int month)
        {
            if (month >= 1 && month <= 12)
            {
                timeInts[1] = month;
            }
        }

        public int GetDay()
        {
            return timeInts[2];
        }

        public void SetDay(int day)
        {
            int maxDays;

            if (timeInts[1] == 9 || timeInts[1] == 4 || timeInts[1] == 6 || timeInts[1] == 11) //30 days hath September, April, June, and November
            {
                maxDays = 30;
            }
            else if (timeInts[1] == 2) //of course February just has to be a pain in the ass
            {
                if (((float) timeInts[0]) % 4 == 0 && (((float) timeInts[0]) % 100 != 0 || ((float) timeInts[0]) % 400 == 0))
                {
                    maxDays = 29;
                }
                else
                {
                    maxDays = 28;
                }
            }
            else //all the rest have 31
            {
                maxDays = 31;
            }

            if (day >= 1 && day <= maxDays)
            {
                timeInts[2] = day;
            }
        }

        public int GetTime()
        {
            return timeInts[3];
        }

        public void SetTime(int time)
        {
            if (time >= 0 && time <= 2359)
            {
                if (time % 100 > 59)
                {
                    time -= time % 100;
                    time += 100;
                }
            }
            timeInts[3] = time;
        }

        public void SetDate(DateTime datetime)
        {
            SetYear(datetime.Year);
            SetMonth(datetime.Month);
            SetDay(datetime.Day);
        }

        public bool IsBefore(Task other)
        {
            if (timeInts[0] < other.GetYear())
            {
                return true;
            }
            else if (timeInts[0] == other.GetYear())
            {
                if (timeInts[1] < other.GetMonth())
                {
                    return true;
                }
                else if (timeInts[1] == other.GetMonth())
                {
                    if (timeInts[2] < other.GetDay())
                    {
                        return true;
                    }
                    else if (timeInts[2] == other.GetDay())
                    {
                        if (timeInts[3] < other.GetTime())
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool TimeEquals(Task other)
        {
            return (timeInts[0] == other.GetYear() && timeInts[1] == other.GetMonth() && timeInts[2] == other.GetDay() && timeInts[3] == other.GetTime());
        }

        public bool IsAfter(Task other)
        {
            return (!IsBefore(other) && !TimeEquals(other));
        }

        public int CompareTime(Task other)
        {
            if (IsBefore(other))
            {
                return -1;
            }
            else if (TimeEquals(other))
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public string GetTimeStamp()
        {
            return timeInts[0].ToString("0000") + timeInts[1].ToString("00") + timeInts[2].ToString("00") + timeInts[3].ToString("0000");
        }

        private string GetTimeString()
        {
            return timeInts[1].ToString("00") + "/" + timeInts[2].ToString("00") + "/" + timeInts[0].ToString("0000") + " @ " + timeInts[3].ToString("0000") + ":  ";
        }

        public string GetString()
        {
            return GetTimeString() + " " + infoStrings[0] + " - " + infoStrings[1] + " - " + infoStrings[2] + " - " + infoStrings[3];
        }

        public void SetLocation(int x, int y)
        {
            Location = new Point(x, y);
        }

        public void ShowText()
        {
            Text = GetString();
        }
    }
}