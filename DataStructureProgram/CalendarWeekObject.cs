using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureProgram
{
    public class CalendarWeekObject<T>
    {
        public string date;
        public string day;
        public CalendarWeekObject<T> next;
        public CalendarWeekObject<T> head;

        public CalendarWeekObject()
        {
        }
        public CalendarWeekObject(string day, string date)
        {
            this.date = date;
            this.day = day;
            this.next = null;
        }
        public void AddLast(CalendarWeekObject<T> newNode)
        {
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                CalendarWeekObject<T> temp = GetLastNode();
                temp.next = newNode;

            }
        }
        //Return Last node in Linked List
        public CalendarWeekObject<T> GetLastNode()
        {
            CalendarWeekObject<T> temp = head;
            while (temp.next != null)
            {
                temp = temp.next;
            }
            return temp;
        }

        public void DisplayWeek()
        {
            CalendarWeekObject<T> temp = head;
            while (temp != null)
            {
                if (temp.date == "")
                {
                    Console.Write("   "+" ");
                    temp = temp.next;
                    continue;
                }

                Console.Write(temp.date+"   ");
               
                temp = temp.next;
            }
            Console.WriteLine("\n");
        }
    }
    }
