using System;
using System.Threading;

namespace ConsoleApp1
{
  class Program
  {

    static int[] hsnek = { 20, 20, 20, 20, 20, 20, 20, 20, 20 };
		static int[] vsnek = { 20, 20, 20, 20, 20, 20, 20, 20, 20 };
    static string snekword = "ok,boomer";
    static int head = 0;
    static TimeSpan time_step = TimeSpan.FromSeconds(.2);
    static DateTime next_step_time = DateTime.Now.Add(time_step);
    static int gettailindex()
    {
      if (head == 0)
      {
        return snekword.Length - 1;
      }
      return head - 1;
    }
    static int getnextindex(int index)
    {
      return index % (snekword.Length);
    }
    static void clearchar(int hpos, int vpos)
    {
      writechar(hpos, vpos, ' ');
    }
    static void writechar(int hpos, int vpos, char letter)
    {
      try
      {
        Console.SetCursorPosition(hpos, vpos);
      }
      catch (ArgumentOutOfRangeException ex)
      {
        Console.WriteLine(ex);
      }
      finally
      {
        Console.Write(letter);
      }
    }
    static void drawthesnek()
    {
      int i = head;

      do
      {
        writechar(hsnek[i], vsnek[i], snekword[i]);
        getnextindex(i);
      } while (i != head){

      }
    }
		static void goon(int direction) {
			switch (direction) {
				case 0:
          vsnek[gettailindex()] = vsnek[head] - 1;
					break;
				case 1:
          hsnek[gettailindex()] = hsnek[head] - 1;
					break;
				case 2:
          vsnek[gettailindex()] = vsnek[head] + 1;
					break;
				case 3:
          hsnek[gettailindex()] = hsnek[head] + 1;
					break;
			}
      head = gettailindex();
      drawthesnek();
    }
		static void Main(string[] args)
    {
			ConsoleKey lastkey = ConsoleKey.Escape;
			bool keyavailable = false;
			int lastdirection = 0;
			while ((keyavailable=Console.KeyAvailable) ? (lastkey = Console.ReadKey(true).Key) != ConsoleKey.Escape : true) {
				if (keyavailable) {
					switch (lastkey) {
						case ConsoleKey.W:
							lastdirection = 0;
							break;
						case ConsoleKey.A:
							lastdirection = 1;
							break;
						case ConsoleKey.S:
							lastdirection = 2;
							break;
						case ConsoleKey.D:
							lastdirection = 3;
							break;
					}
				}
        if(DateTime.Now>=next_step_time){
		    goon(lastdirection);
          while(DateTime.Now>=next_step_time){
            next_step_time = next_step_time.Add(time_step);
          }
        }
			}//game while
    }//main

  }
}
