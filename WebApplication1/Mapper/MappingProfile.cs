using AutoMapper;
using OnlineShopping.ViewModel.Order;
using WebApplication1.Models;

namespace OnlineShopping.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<AddOrderViewModel, Order>();
            CreateMap<Order , OrderDetailsViewModel>();
            CreateMap<OrderDetailsViewModel,Order>();
            CreateMap<OrderItem,OrderDetailsViewModel>();
            
        }
    }
}
