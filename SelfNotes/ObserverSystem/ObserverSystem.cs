using System;
using System.Collections.Generic;

namespace ObserverSystem
{
	public struct Location
	{
		double lat, lon;
		public Location(double lat, double lon)
		{
			this.lat = lat;
			this.lon = lon;
		}
		public double Latitude { get { return this.lat; } }
		public double Longitude { get { return this.lon; } }
	}

	public class LocationReporter : IObserver<Location>
	{
		private IDisposable unsubscriber;
		private string instName;

		public string Name
		{ get { return this.instName; } }

		public LocationReporter(string name)
		{
			this.instName = name;
		}

		public virtual void Subscribe(IObservable<Location> provider)
		{
			if (provider != null)
				unsubscriber = provider.Subscribe(this);
		}

		/// <summary>
		/// IObserver Implementation
		/// </summary>
		public void OnCompleted()
		{
			Console.WriteLine("The Location Tracker has completed transmitting data to {0}.", this.Name);
			this.Unsubscribe();
		}

		/// <summary>
		/// IObserver Implementation
		/// </summary>
		public void OnError(Exception error)
		{
			Console.WriteLine("{0}: The location cannot be determined.", this.Name);

		}

		/// <summary>
		/// IObserver Implementation
		/// </summary>
		public void OnNext(Location value)
		{
			Console.WriteLine("{2}: The current location is {0}, {1}", value.Latitude, value.Longitude, this.Name);

		}
		public virtual void Unsubscribe()
		{
			unsubscriber.Dispose();
		}
	}

	public class LocationTracker : IObservable<Location>
	{
		List<IObserver<Location>> observers;
		public LocationTracker()
		{
			observers = new List<IObserver<Location>>();
		}

		public void DoSomething()
		{
			foreach (IObserver<Location> observer in observers)
			{
				observer.OnNext(new Location(123, 4565));
			}
		}

		public void Flee()
		{
			foreach (IObserver<Location> observer in observers.ToArray())
			{
				observer.OnCompleted();
			}
			observers.Clear();
		}
		/// <summary>
		/// IObservable Implementation
		/// </summary>
		/// <param name="observer"></param>
		/// <returns></returns>
		public IDisposable Subscribe(IObserver<Location> observer)
		{
			if (!this.observers.Contains(observer))
			{
				observers.Add(observer);
			}
			return new Unsubscriber(observers, observer);
		}

		private class Unsubscriber : IDisposable
		{
			List<IObserver<Location>> observers;
			IObserver<Location> observer;
			public Unsubscriber(List<IObserver<Location>> observers, IObserver<Location> observer)
			{
				this.observers = observers;
				this.observer = observer;
			}
			/// <summary>
			/// IDisposable Implementation
			/// </summary>
			public void Dispose()
			{
				if (observers.Contains(observer))
				{
					observers.Remove(observer);
				}
			}
		}
	}
}