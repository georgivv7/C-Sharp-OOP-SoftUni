using System;
using System.Collections.Generic;
using System.Text;

namespace P02_CarsSalesman
{
    public class Car
    {
        private const string offset = "  ";

        public string model;
        public Engine engine;
        public int weight;
        public string color;

        public Car(string model, Engine engine)
        {
            this.model = model;
            this.engine = engine;
            this.weight = 0;
            this.color = "";
        }
        public Car(string model, Engine engine, int weight)
        {
            this.model = model;
            this.engine = engine;
            this.weight = weight;
            this.color = "";
        }
        public Car(string model, Engine engine,string color)
        {
            this.model = model;
            this.engine = engine;
            this.weight = 0;
            this.color = color;
        }
        public Car(string model, Engine engine, int weight, string color)
        {
            this.model = model;
            this.engine = engine;
            this.weight = weight;
            this.color = color;
        }
        public override string ToString()
        {
            string weight = this.weight == 0 ? "n/a" : this.weight.ToString();
            string color = this.color == "" ? "n/a" : this.color;
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat($"{this.model}:\n");
            sb.Append(this.engine.ToString());
            sb.AppendFormat($"{offset}Weight: {weight}\n");
            sb.AppendFormat($"{offset}Color: {color}");

            return sb.ToString();
        }
    }
}
