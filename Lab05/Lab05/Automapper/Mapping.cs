using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Lab05.Model;
using Lab05.ViewModel;

namespace Lab05.Automapper
{
    class Mapping
    {
        public void Create()
        {
            Mapper.CreateMap<DataModel, DataViewModel>();
            Mapper.CreateMap<DataViewModel, DataModel>();

            Mapper.CreateMap<Client, ClientViewModel>();
            Mapper.CreateMap<ClientViewModel, Client>();

            Mapper.CreateMap<Order, OrderViewModel>();
            Mapper.CreateMap<OrderViewModel, Order>();

            Mapper.CreateMap<Product, ProductViewModel>();
            Mapper.CreateMap<ProductViewModel, Product>();
        }
    }
}
