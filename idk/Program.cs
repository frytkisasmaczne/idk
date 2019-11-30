using System;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {

		static int hpos = 20;
		static int vpos = 20;
        static TimeSpan time_step = TimeSpan.FromSeconds(.2);
        static DateTime next_step_time = DateTime.Now;

		static void goon(int direction) {
            try
            {
                Console.SetCursorPosition(hpos, vpos);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex);
            }
			Console.Write(' ');
			switch (direction) {
				case 0:
					vpos -= 1;
					break;
				case 1:
					hpos -= 1;
					break;
				case 2:
					vpos += 1;
					break;
				case 3:
					hpos += 1;
					break;
			}
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
                Console.Write('#');
            }
			
		}
		static void Main(string[] args)
        {
			ConsoleKey lastkey = ConsoleKey.Escape;
			bool keyavailable = false;
			int lastdirection = 0;
			while ((keyavailable=Console.KeyAvailable) ? (lastkey = Console.ReadKey().Key) != ConsoleKey.Escape : true) {
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
			}
        }
    }
}
