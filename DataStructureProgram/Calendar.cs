using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureProgram
{
    public class Calendar
    {
        int month;
        int year;
        int[,] calendar;
        string[] months = { "January", "Feburary", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        int currentDay = 1;
        public Calendar(int month,int year)
        {
            this.month = month;
            this.year = year;
            this.calendar = new int[6, 7];
        }
        public void Header()
        {
            Console.WriteLine("*******Calendar "+month+"-"+year+"*******");
            Console.WriteLine(months[month-1]+" "+year);
            Console.WriteLine("Sun Mon Tue Wed Thur Fri Sat");
        }
        public static int DayFromDate(int date, int month, int year)
        {
            int yo = year - (14 - month) / 12;
            int x = yo + yo / 4 - yo / 100 + yo / 400;
            int mo = month + 12 * ((14 - month) / 12) - 2;
            int d0 = (date + x + 31 * mo / 12) % 7;
            return d0;
        }
        public void FillFirstRow(int startDate)
        {
            while (startDate<7)
            {
                calendar[0, startDate] = currentDay;
                startDate++;
                currentDay++;
            }
        }
        public void CalenderFill()
        {
            int startDate = DayFromDate(1, month, year);
            int days = DateTime.DaysInMonth(year, month);
            FillFirstRow(startDate);
            for (int i = 1; i < 6; i++)
            {
                for (int j = 0; j < 7&&currentDay<=days; j++)
                {
                    calendar[i, j] = currentDay++;

                }
            }

        }
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
    }

}
