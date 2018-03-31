using System.ComponentModel;
using System.Runtime.CompilerServices;
using AsyncRepository.Annotations;

namespace AsyncRepository
{
	public class Customer : INotifyPropertyChanged
	{
		private int? _id;
		private string _firstName;
		private string _lastName;
		private int _age;

		public int? Id
		{
			get => _id;
			set
			{
				if (value == _id) return;
				_id = value;
				OnPropertyChanged();
			}
		}

		public string FirstName
		{
			get => _firstName;
			set
			{
				if (value == _firstName) return;
				_firstName = value;
				OnPropertyChanged();
			}
		}

		public string LastName
		{
			get => _lastName;
			set
			{
				if (value == _lastName) return;
				_lastName = value;
				OnPropertyChanged();
			}
		}

		public int Age
		{
			get => _age;
			set
			{
				if (value == _age) return;
				_age = value;
				OnPropertyChanged();
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
