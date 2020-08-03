using System;

namespace Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            const string models =
                @"namespace Model
                {
                    public class Model
                    {
                        [Get]
                        public string Name { get; set; }
                        [Get]
                        public int MakeId { get; set; }

                    }
                }";
            Generator.Generate(models);
        }
    }
}
