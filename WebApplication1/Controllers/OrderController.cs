using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using OnlineShopping.Reposatory;
using OnlineShopping.ViewModel.Order;
using WebApplication1.Models;
using static NuGet.Packaging.PackagingConstants;

namespace OnlineShopping.Controllers
{
    public class OrderController : Controller
    {
         IReposatory<Order> _reposatory;
         IReposatory<OrderItem> _itemReposatory;
        IMapper _mapper;
        public OrderController(IReposatory<Order> reposatory, IMapper mapper, IReposatory<OrderItem> itemReposatory)
        {
            _reposatory = reposatory;
            _itemReposatory= itemReposatory;
             IMapper _mapper;
        }
        
        public IActionResult Index()
        {
           var orders = _reposatory.GetAll();
         // var orderMapped = _mapper.Map<List<OrderDetailsViewModel>>(orders);

            return View("Index", orders);
        }
        public IActionResult Details(int id)
        {
            Order order = _reposatory.GetById(id);
            var orderMapped = _mapper.Map<OrderDetailsViewModel>(order);
            return View("Details", orderMapped);
        }

        public IActionResult Save(AddOrderViewModel orderViewModel)
        {
            var orderMapped = _mapper.Map<Order>(orderViewModel);
            var orderItemMapped = _mapper.Map<OrderItem>(orderViewModel.OrderItems);
            _reposatory.Insert(orderMapped);
            _itemReposatory.Insert(orderItemMapped);

            _reposatory.Save();
            return Content("The product added to cart successfully!");
        }
        public IActionResult Delete(int id)
        {
            _reposatory.Delete(id);
            _reposatory.Save();
            return View("Index");
        }

        public IActionResult Update(int id)
        {
            Order order  = _reposatory.GetById(id);
            return View("Detail", order);
        }
        public IActionResult SaveUpdate(Order order)
        {
             _reposatory.Update(order);
            _reposatory.Save();
            return View("Index");
        }
    }
}
