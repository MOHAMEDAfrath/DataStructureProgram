using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureProgram
{
    public class Calendar
    {
        //variables are declared
        int month;
        int year;
        int[,] calendar;
        string[] months = { "January", "Feburary", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        int currentDay = 1;
        public static Queue<CalendarWeekObject<Calendar>> week = new Queue<CalendarWeekObject<Calendar>>();
        List<string> weeks = new List<string>() { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
        public Calendar(int month,int year)
        {
            this.month = month;
            this.year = year;
            this.calendar = new int[6, 7];
        }
        //prints the header of calendar
        public void Header()
        {
            Console.WriteLine("*******Calendar "+month+"-"+year+"*******");
            Console.WriteLine(months[month-1]+" "+year);
            Console.WriteLine("Sun Mon Tue Wed Thur Fri Sat");
        }
        //to find the day on which the date falls
        public static int DayFromDate(int date, int month, int year)
        {
            int yo = year - (14 - month) / 12;
            int x = yo + yo / 4 - yo / 100 + yo / 400;
            int mo = month + 12 * ((14 - month) / 12) - 2;
            int d0 = (date + x + 31 * mo / 12) % 7;
            return d0;
        }
        //fill the first row of the month calendar
        public void FillFirstRow(int startDate)
        {
            //creating weekdayqueue with class as type
            CalendarWeekObject<Calendar> weekDayQueue = new CalendarWeekObject<Calendar>();
            int j = 0;
            while (j < startDate)
            {
                CalendarWeekObject<Calendar> calenderUsingWeekObjects = new CalendarWeekObject<Calendar>(weeks[j], "");
                weekDayQueue.AddLast(calenderUsingWeekObjects);
                j++;

            }
           
            while (startDate<7)
            {
                
                calendar[0, startDate] = currentDay;
                CalendarWeekObject<Calendar> calenderUsingWeekObjects = new CalendarWeekObject<Calendar>(weeks[startDate], Convert.ToString(currentDay));
                weekDayQueue.AddLast(calenderUsingWeekObjects);
                startDate++;
                currentDay++;
            }
            week.Enqueue(weekDayQueue);
        }
        //fills the rest of the calendar
        public void CalenderFill()
        {
            int startDate = DayFromDate(1, month, year);
            int days = DateTime.DaysInMonth(year, month);
            FillFirstRow(startDate);
            for (int i = 1; i < 6; i++)
            {
                CalendarWeekObject<Calendar> weekDayQueue = new CalendarWeekObject<Calendar>();
                for (int j = 0; j < 7&&currentDay<=days; j++)
                {

                    calendar[i, j] = currentDay++;
                    CalendarWeekObject<Calendar> calenderUsingWeekObjects = new CalendarWeekObject<Calendar>(weeks[j], Convert.ToString(calendar[i,j]));
                    weekDayQueue.AddLast(calenderUsingWeekObjects);
                }
                week.Enqueue(weekDayQueue);
            }
          

        }
        //displaying the calendar
        public void DisplayCalendar()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if(calendar[i,j]!=0)
                        Console.Write(calendar[i,j]+"  ");
                    else
                        Console.Write("*"+ "  ");

                }
                Console.WriteLine(" ");
            }
        }
        //Display for queue
        public void Display()
        {
            Header();
            foreach (var i in week)
            {
                i.DisplayWeek();
            }
        }
    }

}
