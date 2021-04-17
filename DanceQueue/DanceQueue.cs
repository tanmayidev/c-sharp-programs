using System;
using System.Collections;
using System.IO;
// 20, 30, 23, 

// 20, 30, 23, 45, 34, 55, ...................

// 20, 30, 23, 45, 34, 55, 66, 77, 

    // 20p,     45p, 34p, 55p, 66p,  77



namespace DanceQueue {
    public struct Dancer {
        public string name;
        public string sex;
        public void GetName(string n) {
            name = n;
        }
        public override string ToString() {
            return name;
        }
    }
    class Class1 {
        static void newDancers(Queue male, Queue female) {
            Dancer m, w;
            m = new Dancer();
            w = new Dancer();
            if (male.Count > 0 && female.Count > 0) {
                m.GetName(male.Dequeue().ToString());
                w.GetName(female.Dequeue().ToString());
            } else if ((male.Count > 0) && (female.Count ==
              0))
                Console.WriteLine("Waiting on a female dancer.");
              else if ((female.Count > 0) && (male.Count ==
              0))
                Console.WriteLine("Waiting on a male dancer.");
        }
        static void headOfLine(Queue male, Queue female) {
            Dancer w, m;
            m = new Dancer();
            w = new Dancer();
            if (male.Count > 0)
                m.GetName(male.Peek().ToString());
            if (female.Count > 0)
                w.GetName(female.Peek().ToString());
            if (m.name != " " && w.name != "")
                Console.WriteLine("Next in line are: " + 
                m.name + "\t"
                + w.name);
            else
            if (m.name != "")
                Console.WriteLine("Next in line is: " +
                m.name);
            else
                Console.WriteLine("Next in line is: " +
                w.name);
        }
        static void startDancing(Queue male, Queue female) {
            Dancer m, w;
            m = new Dancer();
            w = new Dancer();
            Console.WriteLine("Dance partners are: ");
            Console.WriteLine();
            for (int count = 0; count <= 3; count++) {
                m.GetName(male.Dequeue().ToString());
                w.GetName(female.Dequeue().ToString());
                Console.WriteLine(w.name + "\t" + m.name);
            }
        }
        static void formLines(Queue male, Queue female) {
            Dancer d = new Dancer();
            StreamReader inFile;
            inFile = File.OpenText("Dancers.txt");
            string line;
            while (inFile.Peek() != -1) {
                line = inFile.ReadLine();
                d.sex = line.Substring(0, 1);
                d.name = line.Substring(2, line.Length - 2);
                if (d.sex == "M")
                    male.Enqueue(d);
                else
                    female.Enqueue(d);
            }
        }
        static void Main(string[] args) {
           Queue males = new Queue();
           Queue females = new Queue();
           formLines(males, females);
           startDancing(males, females);
           if (males.Count > 0 || females.Count > 0)
               headOfLine(males, females);
           newDancers(males, females);
           if (males.Count > 0 || females.Count > 0)
               headOfLine(males, females);
           newDancers(males, females);
           Console.Write("press enter");
           Console.Read();
        }
    }
}
