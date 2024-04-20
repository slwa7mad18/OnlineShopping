using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Reposatory;
using OnlineShopping.ViewModel.Order;
using OnlineShopping.ViewModel.OrderItem;
using WebApplication1.Models;

namespace OnlineShopping.Controllers
{
    public class OrderItemController : Controller
    {
        IReposatory<OrderItem> _reposatory;
        IMapper _mapper;
        public OrderItemController(IReposatory<OrderItem> reposatory, IMapper mapper)
        {
            _mapper = mapper;
            _reposatory = reposatory;
        }
        public IActionResult Index()
        {
            var orderItems = _reposatory.GetAll();
           // var orderItemMapped = _mapper.Map<List<OrderItemDetailsViewModel>>(orderItems);

            return View("Index", orderItems);
        }
        public IActionResult Details(int id)
        {
            OrderItem orderItem = _reposatory.GetById(id);
            var orderItemMapped = _mapper.Map<OrderItemDetailsViewModel>(orderItem);
            return View("Details", orderItemMapped);
        }
    }
}
