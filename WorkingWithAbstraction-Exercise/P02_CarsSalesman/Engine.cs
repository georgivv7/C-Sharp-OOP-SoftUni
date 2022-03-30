using System;
using System.Collections.Generic;
using System.Text;

namespace P02_CarsSalesman
{
    public class Engine
    {
        private const string offset = "  ";

        public string model;
        public int power;
        public int displacement;
        public string efficiency;

        public Engine(string model, int power)
        {
            this.model = model;
            this.power = power;
            this.displacement = 0;
            this.efficiency = "";
        }
        public Engine(string model, int power, int displacement)
        {
            this.model = model;
            this.power = power;
            this.displacement = displacement;
            this.efficiency = "";
        }
        public Engine(string model, int power,string efficiency)
        {
            this.model = model;
            this.power = power;
            this.displacement = 0;
            this.efficiency = efficiency;
        }
        public Engine(string model, int power, int displacement, string efficiency)
        {
            this.model = model;
            this.power = power;
            this.displacement = displacement;
            this.efficiency = efficiency;
        }
        public override string ToString()
        {
            string displacement = this.displacement == 0 ? "n/a" : this.displacement.ToString();
            string efficiency = this.efficiency == "" ? "n/a" : this.efficiency;
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat($"{offset}{this.model}:\n");
            sb.AppendFormat($"{offset}{offset}Power: {this.power}\n");
            sb.AppendFormat($"{offset}{offset}Displacement: {displacement}\n");
            sb.AppendFormat($"{offset}{offset}Efficiency: {efficiency}\n");

            return sb.ToString();
        }
    }
}
