namespace FestivalManager.Entities.Instruments
{
	using Contracts;
	using System;
	public abstract class Instrument : IInstrument
	{
		private const int MaxWear = 100;

		private double wear;	
		protected Instrument()
		{
			this.Wear = MaxWear;
		}

		public double Wear
		{
			get
			{
				return this.wear;
			}
			private set
			{
                if (value < 0)
                {
					this.wear = 0;
                }
                else if (value > MaxWear)
                {
					this.wear = MaxWear;
                }
                else
                {
					this.wear = value;
                }
			}
		}

		protected abstract int RepairAmount { get; }

		public void Repair() => this.Wear += this.RepairAmount;

		public void WearDown() => this.Wear -= this.RepairAmount;

		public bool IsBroken => this.Wear <= 0;

		public override string ToString()
		{
			var instrumentStatus = this.IsBroken ? "broken" : $"{this.Wear}%";

			return $"{this.GetType().Name} [{instrumentStatus}]";
		}
	}
}
