using System;
using System.Threading;

namespace ConsoleApp1
{
  class Program
  {
    static Random rand = new Random();
    static int[] hsnek;
    static int[] vsnek;
    static string snekword = "Ok, boomer.";//feel free to change the string
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
    static int roundtoindex(int index)
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
      for (int i = 0; i < snekword.Length; i++)
      {
        writechar(hsnek[roundtoindex(head + i)], vsnek[roundtoindex(head + i)], snekword[i]);
      }
    }
    static void goon(int direction)
    {
      clearchar(hsnek[gettailindex()], vsnek[gettailindex()]);
      switch (direction)
      {
        case 0:
          vsnek[gettailindex()] = vsnek[head] - 1;
          hsnek[gettailindex()] = hsnek[head];
          break;
        case 1:
          hsnek[gettailindex()] = hsnek[head] - 1;
          vsnek[gettailindex()] = vsnek[head];
          break;
        case 2:
          vsnek[gettailindex()] = vsnek[head] + 1;
          hsnek[gettailindex()] = hsnek[head];
          break;
        case 3:
          hsnek[gettailindex()] = hsnek[head] + 1;
          vsnek[gettailindex()] = vsnek[head];
          break;
      }

      head = gettailindex();
      drawthesnek();
    }
    static int[] generatenextdrop()
    {
      int[] point = new int[2];
      point[0] = rand.Next(Console.WindowWidth);
      point[1] = rand.Next(Console.WindowHeight);
      //yes, i considered checking against the snake 
      //position, but since i would have to go through
      //the entire array it doesn't seem to be worth it
      return point;
    }

    static void Main(string[] args)
    {
      Array.Resize(ref hsnek, snekword.Length);
      Array.Resize(ref vsnek, snekword.Length);
      for (int i = 0; i < snekword.Length; i++)
      {
        hsnek[i] = 20;
        vsnek[i] = 20;
      }
      ConsoleKey lastkey = ConsoleKey.Escape;
      bool keyavailable = false;
      int lastdirection = 0;
      while ((keyavailable = Console.KeyAvailable) ? (lastkey = Console.ReadKey(true).Key) != ConsoleKey.Escape : true)
      {
        if (keyavailable)
        {
          switch (lastkey)
          {
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
        if (DateTime.Now >= next_step_time)
        {
          goon(lastdirection);
          while (DateTime.Now >= next_step_time)
          {
            next_step_time = next_step_time.Add(time_step);
          }
        }
      }//game while
    }//main

  }
}
