using System;

namespace BaseChildAssignmentConfusion
{
    class Program
    {
        static void Main(string[] args)
        {

            Base @base = new Child
            {
                Id = 1,
                AdditionalProperty = 4
            };

            Console.WriteLine(@base.GetType());//Prints BaseChildAssignmentConfusion.Child but in comple time not able to access AdditionalProperty...WHY???
            
            Console.WriteLine(((Child)@base).AdditionalProperty);//Explicit casting is needed to print AdditionProperty value

            //Child child = new Base();//Compile time error so this is not feasible

            Base base2 = Test();
            Console.ReadKey();
            


        }

        private static Child Test()
        {
            return new Child
            {
                Id = 1,
                AdditionalProperty = 2
            };
        }
    }
    public class Base
    {
        public int Id { get; set; }
    }

    public class Child : Base
    {
        public int AdditionalProperty { get; set; }
    }

   
}





