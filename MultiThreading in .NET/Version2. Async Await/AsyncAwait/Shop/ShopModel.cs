﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Shop.Annotations;

namespace Shop
{
	public class ShopModel : INotifyPropertyChanged
	{
		private IList<Product> _products = new List<Product>()
		{
			new Product{Id = 1, Name = "Пицца", Price = 50.0m},
			new Product{Id = 2, Name = "Чай", Price = 5.0m},
			new Product{Id = 3, Name = "Кофе", Price = 7.5m},
			new Product{Id = 4, Name = "Чебурек", Price = 20.0m},
			new Product{Id = 5, Name = "Молоко", Price = 15.0m},
			new Product{Id = 6, Name = "Печенье", Price = 10.0m},
		};

		private IList<Product> _selectedProducts = new ObservableCollection<Product>();
		private decimal? _sum;

		public IList<Product> AllProducts => _products;

		public IList<Product> SelectedProducts => _selectedProducts;

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

		public async void Add(int productId)
		{
			await new TaskFactory().StartNew(() =>
			{
				var product = _products.FirstOrDefault(p => p.Id == productId);
				if (!_selectedProducts.Contains(product) && product != null)
				{
					_selectedProducts.Add(product);
					Recalculate();
				}
			}, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
		}

		public async void Delete(Product product)
		{
			await new TaskFactory().StartNew(() =>
			{
				if (_selectedProducts.Contains(product))
				{
					_selectedProducts.Remove(product);
					Recalculate();
				}
			}, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
		}

		private async void Recalculate()
		{
			Sum = await Task.Run(() => _selectedProducts.Sum(p => p.Price));
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}