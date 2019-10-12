using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netetst
{
    public class FileManager
    {
        public static void save()
        {
            string[] lines = new string[3];
            
            for (int i = 0; i <= 2; i++)
            {
                lines[i] = GameEnvironment.hi[i].ToString();
                //GameEnvironment.hi[0] = p1;
                //GameEnvironment.hi[1] = p2;
                //GameEnvironment.hi[2] = p3;
            }
            System.IO.Directory.CreateDirectory(@"C:\Users\Public\Ssssss\");
            System.IO.File.WriteAllLines(@"C:\Users\Public\Ssssss\save.txt", lines);
        }
        public static void load()
        {
            if (!System.IO.File.Exists(@"C:\Users\Public\Ssssss\save.txt"))
            {
                GameEnvironment.hi[0] = 0;
                GameEnvironment.hi[1] = 0;
                GameEnvironment.hi[2] = 0;
            }
            else
            {

                int i = 0;
                string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Public\Ssssss\save.txt");
                foreach (string line in lines)
                {
                    if (!Int32.TryParse(line, out GameEnvironment.hi[i]))
                    {
                        GameEnvironment.hi[i] = 0;
                    }
                    i++;
                    //Console.WriteLine("\t" + line);
                }
            }
        }
    }
}
