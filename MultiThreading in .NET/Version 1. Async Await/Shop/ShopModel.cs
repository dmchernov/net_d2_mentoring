using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Shop.Annotations;

namespace Shop
{
	public class ShopModel : INotifyPropertyChanged
	{
		public ShopModel()
		{
			_selectedProducts.CollectionChanged += _selectedProducts_CollectionChanged;
		}

		private void _selectedProducts_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
		    OnPropertyChanged(nameof(SelectedProducts));
		}

		private IList<Product> _products = new List<Product>()
		{
			new Product{Id = 1, Name = "Пицца", Price = 50.0m},
			new Product{Id = 2, Name = "Чай", Price = 5.0m},
			new Product{Id = 3, Name = "Кофе", Price = 7.5m},
			new Product{Id = 4, Name = "Чебурек", Price = 20.0m},
			new Product{Id = 5, Name = "Молоко", Price = 15.0m},
			new Product{Id = 6, Name = "Печенье", Price = 10.0m},
		};

		private ObservableCollection<Product> _selectedProducts = new ObservableCollection<Product>();
		private decimal? _sum;

		public IList<Product> AllProducts => _products.Except(_selectedProducts).ToList();

		public IList<Product> SelectedProducts => _selectedProducts;

		public bool CanRemove => SelectedProducts?.Count > 0;

		public decimal? Sum
		{
			get => _sum;
			set
			{
				if (value == _sum) return;
				_sum = value;
				OnPropertyChanged();
			}
		}

		public async Task Add(int productId)
		{
			await new TaskFactory().StartNew(() =>
			{
				var product = _products.FirstOrDefault(p => p.Id == productId);
				if (product != null)
				{
					_selectedProducts.Add(product);
				    OnPropertyChanged(nameof(CanRemove));
					Recalculate();
				}
			});
		}

		public async Task Delete(int productId)
		{
			await new TaskFactory().StartNew(() =>
			{
			    var product = _selectedProducts.FirstOrDefault(p => p.Id == productId);
				if (product != null)
				{
					_selectedProducts.Remove(product);
				    OnPropertyChanged(nameof(CanRemove));
					Recalculate();
				}
			});
		}

		private async void Recalculate()
		{
			Sum = await Task.Factory.StartNew(() =>
			{
				return _selectedProducts.Sum(p => p.Price);
			});
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
